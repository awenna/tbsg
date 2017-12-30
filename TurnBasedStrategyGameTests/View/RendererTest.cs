using System.Collections.Generic;
using System.Drawing;
using Xunit;
using Rhino.Mocks;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Data.View;
using TBSG.Model.Hexmap;
using TBSG.View.Drawing;

namespace TBSG.View
{
    public class RendererTest
    {
        #region Fields

        private readonly IAlgorithms mAlgorithms;
        private readonly ICameraController mCameraController;
        private readonly IGraphics mGraphics;
        private readonly IGridDrawer mGridDrawer;
        private readonly IMap mMap;
        private readonly ISelection mSelection;
        private readonly TestConfigurationProvider mConfigProvider;

        private readonly Camera mCamera = new Camera();
        private readonly Renderer Target;

        #endregion

        #region Constructor

        public RendererTest()
        {
            mAlgorithms = MockRepository.GenerateMock<IAlgorithms>();
            mCameraController = MockRepository.GenerateMock<ICameraController>();
            mGraphics = MockRepository.GenerateMock<IGraphics>();
            mGridDrawer = MockRepository.GenerateStub<IGridDrawer>();
            mMap = MockRepository.GenerateStub<IMap>();
            mSelection = MockRepository.GenerateStub<ISelection>();
            mConfigProvider = new TestConfigurationProvider();

            mCameraController.Stub(_ => _.GetCamera()).Return(mCamera);

            Target = new Renderer(mAlgorithms, mMap, mGridDrawer, mConfigProvider);
        }

        #endregion

        #region DrawGrid

        [Fact]
        public void DrawGrid_TileNotOnMap_NoDrawing()
        {
            mCameraController.Stub(_ => _.GetHexesInView())
                .Return(new List<HexCoordinate> { XY.Hex(0, 0) });

            mCameraController.Stub(_ => _.GetCamera())
                .Return(new Camera { Scale = 0 });
            /*
            mMap.Stub(_ => _.TileAt(XY.Hex(0, 0)))
                .Return(null);*/

            Target.DrawGrid(mGraphics, mCameraController);


        }

        #endregion

        #region DrawSelection

        [Fact]
        public void DrawSelection_NoSelection_NoDrawing()
        {
            mConfigProvider.SetValue(2, "SelectionDrawWidth");

            mSelection.Stub(_ => _.Exists()).Return(false);

            Target.DrawSelection(mGraphics, mCameraController, mSelection);

            mGraphics.AssertWasNotCalled(_ => _.DrawPolygon(
                Arg<Pen>.Is.Anything, Arg<Hexagon>.Is.Anything));
        }

        [Fact]
        public void DrawSelection_DrawsSelection()
        {
            mConfigProvider.SetValue(2, "SelectionDrawWidth");

            mMap.Stub(_ => _.LocationOf(mSelection)).Return(XY.Hex(0, 0));
            mSelection.Stub(_ => _.Exists()).Return(true);

            Target.DrawSelection(mGraphics, mCameraController, mSelection);

            mGraphics.AssertWasCalled(_ => _.DrawPolygon(
                Arg<Pen>.Is.Anything, Arg<Hexagon>.Is.Anything));
        }

        #endregion

        #region DrawInfoGraphics


        #endregion

        #region Helpers

        private void StubOneTileOnMap()
        {
            mMap.Stub(_ => _.TileAt(new HexCoordinate(0, 0)))
                .Return(new Tile());
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
