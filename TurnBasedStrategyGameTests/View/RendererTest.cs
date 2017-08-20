using System;
using System.Drawing;
using Xunit;
using Rhino.Mocks;
using TBSG.Data;
using TBSG.Model;

namespace TBSG.View
{
    public class RendererTest
    {
        #region Fields

        private readonly IAlgorithms mAlgorithms;
        private readonly ICameraController mCameraController;
        private readonly IGraphics mGraphics;
        private readonly IMap mMap;
        private readonly TestConfigurationProvider mConfigProvider;

        private readonly Camera mCamera = new Camera();

        #endregion

        #region Constructor

        public RendererTest()
        {
            mAlgorithms = new Algorithms();
            mCameraController = MockRepository.GenerateMock<ICameraController>();
            mGraphics = MockRepository.GenerateMock<IGraphics>();
            mMap = MockRepository.GenerateStub<IMap>();
            mConfigProvider = new TestConfigurationProvider();

            mCameraController.Stub(_ => _.GetCamera()).Return(mCamera);
        }

        #endregion

        #region DrawGrid

        [Fact]
        public void DrawGrid_RequestsCalculationForEachTile()
        {
            var renderer = GenerateRenderer();

            mMap.Stub(_ => _.TileAt(Arg<HexCoordinate>.Is.Anything))
                .Return(GenerateTile());

            StubCameraHexesInView(mCameraController, 0, 0, 3, 5);

            mCamera.Location = XY.World(0, 0);

            renderer.DrawGrid(mGraphics, mCameraController);

            var drawPolyCalls = mGraphics.GetArgumentsForCallsMadeOn(
                _ => _.DrawPolygon(Arg<Pen>.Is.Anything, Arg<Hexagon>.Is.Anything));

            Assert.Equal(48, drawPolyCalls.Count);
        }

        [Fact]
        public void DrawGrid_DrawsOnTilesInView()
        {
            var algorithms = MockRepository.GenerateStub<IAlgorithms>();
            var renderer = new Renderer(algorithms, mMap, mConfigProvider);

            StubCameraHexesInView(mCameraController, 13, 8, 13, 9);

            mMap.Stub(_ => _.TileAt(Arg<HexCoordinate>.Is.Anything))
                .Return(GenerateTile());

            algorithms.Stub(_ => _.GetHexagon(
                Arg<ScreenCoordinate>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new Hexagon(null));

            renderer.DrawGrid(mGraphics, mCameraController);

            algorithms.AssertWasCalled(_ => _.HexToWorld(
                Arg<HexCoordinate>.Is.Equal(new HexCoordinate(13, 8)),
                Arg<int>.Is.Anything));
            algorithms.AssertWasCalled(_ => _.HexToWorld(
                Arg<HexCoordinate>.Is.Equal(new HexCoordinate(13, 9)),
                Arg<int>.Is.Anything));
        }

        [Fact]
        public void DrawGrid_DrawsOnlyTilesOnMap()
        {
            var renderer = GenerateRenderer();

            mMap.Stub(_ => _.TileAt(new HexCoordinate(0, 0)))
                .Return(GenerateTile());

            StubCameraHexesInView(mCameraController, -1, -2, 1, 1);

            mCamera.Location = XY.World(0, 0);

            renderer.DrawGrid(mGraphics, mCameraController);

            var drawPolyCalls = mGraphics.GetArgumentsForCallsMadeOn(
                _ => _.DrawPolygon(Arg<Pen>.Is.Anything, Arg<Hexagon>.Is.Anything));

            Assert.Equal(1, drawPolyCalls.Count);
        }

        #endregion

        #region DrawTiles

        [Fact]
        public void DrawGrid_CallsDrawingOnEachTile()
        {
            var renderer = GenerateRenderer();

            mMap.Stub(_ => _.TileAt(Arg<HexCoordinate>.Is.Anything))
                .Return(GenerateTile());

            StubCameraHexesInView(mCameraController, 0, 0, 1, 2);

            mCamera.Location = XY.World(0, 0);

            renderer.DrawGrid(mGraphics, mCameraController);

            var fillPolyCalls = mGraphics.GetArgumentsForCallsMadeOn(
                _ => _.FillPolygon(Arg<Brush>.Is.Anything, Arg<Hexagon>.Is.Anything));

            Assert.Equal(20, fillPolyCalls.Count);
        }

        [Fact]
        public void DrawGrid_DrawsTilesUsingTerrainColor()
        {
            var renderer = GenerateRenderer();

            mMap.Stub(_ => _.TileAt(Arg<HexCoordinate>.Is.Equal(new HexCoordinate(0, 0))))
                .Return(GenerateTile());

            StubCameraHexesInView(mCameraController, 0, 0, 0, 0);

            mCamera.Location = XY.World(0, 0);

            renderer.DrawGrid(mGraphics, mCameraController);

            mGraphics.AssertWasCalled(
                _ => _.FillPolygon(Arg<Brush>.Matches(brush => brush != null), Arg<Hexagon>.Is.Anything));
        }

        #endregion

        #region DrawUnits

        [Fact]
        public void DrawUnits_RequestsUnitsFromTile()
        {
            var renderer = GenerateRenderer();

            mMap.Stub(_ => _.TileAt(Arg<HexCoordinate>.Is.Equal(new HexCoordinate(0, 0))))
                .Return(GenerateTileWithUnit());

            StubCameraHexesInView(mCameraController, 0, 0, 0, 0);

            mCamera.Location = XY.World(0, 0);

            renderer.DrawUnits(mGraphics, mCameraController);

            mGraphics.AssertWasCalled(_ => _.FillEllipse(
                Arg<Brush>.Is.Anything, Arg<Rectangle>.Is.Anything));
        }

        #endregion

        #region DrawSelection

        [Fact]
        public void DrawSelection_NoSelection_NoDrawing()
        {
            var renderer = GenerateRenderer();

            mConfigProvider.SetValue(2, "SelectionDrawWidth");

            renderer.DrawSelection(mGraphics, mCameraController, null);

            mGraphics.AssertWasNotCalled(_ => _.DrawPolygon(
                Arg<Pen>.Is.Anything, Arg<Hexagon>.Is.Anything));
        }

        #endregion

        #region Helpers

        private void StubCameraHexesInView(
            ICameraController cameraController,
            int x1, int y1, int x2, int y2)
        {
            cameraController.Stub(_ => _.GetHexesInView())
                .Return(Tuple.Create(new HexCoordinate(x1, y1), new HexCoordinate(x2, y2)));
        }

        private void StubOneTileOnMap()
        {
            mMap.Stub(_ => _.TileAt(new HexCoordinate(0, 0)))
                .Return(new Tile());
        }

        private Renderer GenerateRenderer()
        {
            return new Renderer(mAlgorithms, mMap, mConfigProvider);
        }

        private Tile GenerateTile()
        {
            return new Tile(new TerrainType(Color.White));
        }

        private Tile GenerateTileWithUnit()
        {
            var tile = new Tile(new TerrainType(Color.White));
            var unit = new Entity();
            tile.Entity = unit;
            return tile;
        }

        #endregion
    }
}
