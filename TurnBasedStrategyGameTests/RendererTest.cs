using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Xunit;
using Rhino.Mocks;
using TBSG.Data;

namespace TBSG
{
    public class RendererTest
    {
        private readonly IAlgorithms mAlgorithms;
        private readonly ICamera mCamera;
        private readonly IGraphics mGraphics;
        private readonly IMap mMap;

        public RendererTest()
        {
            mAlgorithms = new Algorithms();
            mCamera = MockRepository.GenerateMock<ICamera>();
            mGraphics = MockRepository.GenerateMock<IGraphics>();
            mMap = MockRepository.GenerateStub<IMap>();
        }

        #region DrawGrid

        [Fact]
        public void DrawGrid_RequestsCalculationForEachTile()
        {
            var renderer = new Renderer(mAlgorithms, mMap);

            mMap.Stub(_ => _.TileAt(Arg<HexCoordinate>.Is.Anything))
                .Return(new Tile());

            mCamera.Stub(_ => _.GetHexesInView())
                .Return(Tuple.Create(new HexCoordinate(0, 0), new HexCoordinate(3, 5)));

            mCamera.Stub(_ => _.GetLocation())
                .Return(new WorldCoordinate(0, 0));

            renderer.DrawGrid(mGraphics, mCamera);

            var drawPolyCalls = mGraphics.GetArgumentsForCallsMadeOn(
                _ => _.DrawPolygon(Arg<Pen>.Is.Anything, Arg<Point[]>.Is.Anything));

            Assert.Equal(48, drawPolyCalls.Count);
        }

        [Fact]
        public void DrawGrid_DrawsOnTilesInView()
        {
            var algorithms = MockRepository.GenerateStub<IAlgorithms>();
            var renderer = new Renderer(algorithms, mMap);

            StubCameraHexesInView(mCamera, 13, 8, 13, 9);

            mMap.Stub(_ => _.TileAt(Arg<HexCoordinate>.Is.Anything))
                .Return(new Tile());

            algorithms.Stub(_ => _.GetHexagon(
                Arg<ScreenCoordinate>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new Hexagon(null));

            renderer.DrawGrid(mGraphics, mCamera);

            algorithms.AssertWasCalled(_ => _.HexToWorld(
                Arg<HexCoordinate>.Is.Equal(new HexCoordinate(13, 8)),
                Arg<int>.Is.Anything));
            algorithms.AssertWasCalled(_ => _.HexToWorld(
                Arg<HexCoordinate>.Is.Equal(new HexCoordinate(13, 9)),
                Arg<int>.Is.Anything));
        }

        [Fact]
        public void DrawGrid_UsesCameraScale()
        {
            var renderer = new Renderer(mAlgorithms, mMap);

            mMap.Stub(_ => _.TileAt(Arg<HexCoordinate>.Is.Anything))
                .Return(new Tile());

            StubCameraHexesInView(mCamera, 1, 1, 1, 2);

            mCamera.Stub(_ => _.GetLocation())
                .Return(new WorldCoordinate(0, 0));

            renderer.DrawGrid(mGraphics, mCamera);

            mCamera.AssertWasCalled(_ => _.GetScale());
        }

        [Fact]
        public void DrawGrid_DrawsOnlyTilesOnMap()
        {
            var renderer = new Renderer(mAlgorithms, mMap);

            mMap.Stub(_ => _.TileAt(new HexCoordinate(0, 0)))
                .Return(new Tile());

            StubCameraHexesInView(mCamera, -1, -2, 1, 1);

            mCamera.Stub(_ => _.GetLocation())
                .Return(new WorldCoordinate(0, 0));

            renderer.DrawGrid(mGraphics, mCamera);

            var drawPolyCalls = mGraphics.GetArgumentsForCallsMadeOn(
                _ => _.DrawPolygon(Arg<Pen>.Is.Anything, Arg<Point[]>.Is.Anything));

            Assert.Equal(1, drawPolyCalls.Count);
        }

        #endregion

        #region Helpers

        private void StubCameraHexesInView(
            ICamera camera,
            int x1, int y1, int x2, int y2)
        {
            camera.Stub(_ => _.GetHexesInView())
                .Return(Tuple.Create(new HexCoordinate(x1, y1), new HexCoordinate(x2, y2)));
        }

        private void StubOneTileOnMap()
        {
            mMap.Stub(_ => _.TileAt(new HexCoordinate(0, 0)))
                .Return(new Tile());
        }

        #endregion
    }
}
