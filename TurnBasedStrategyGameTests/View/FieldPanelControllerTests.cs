﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rhino.Mocks;
using Xunit;
using TBSG.Data;
using TBSG.Control;
using TBSG.Model;
using TBSG.View;
using TBSG.View.Forms;

namespace TBSG.View
{
    public class FieldPanelControllerTests
    {
        private readonly IAlgorithms mAlgorithms;
        private readonly IGameController mGameController;
        private readonly IMap mMap;
        private readonly ISelection mSelection;

        public FieldPanelControllerTests()
        {
            mAlgorithms = new Algorithms();
            mGameController = MockRepository.GenerateMock<IGameController>();
            mMap = MockRepository.GenerateStub<IMap>();
            mSelection = MockRepository.GenerateStub<ISelection>();
        }

        [Fact]
        public void OnClickLeft_NoSelection_CreateTileAndUnitSelection()
        {
            var controller = GetFieldPanelController();

            var tile = new Tile();
            mMap.Stub(_ => _.TileAt(Arg<HexCoordinate>.Is.Anything))
                .Return(tile);

            var state = new ViewState { Camera = GenerateCamera(), Selection = mSelection };
            var e = new MouseEventArgs(MouseButtons.Left, 1, 50, 50, 0);

            controller.OnClick(state, e);

            mSelection.AssertWasCalled(_ => _.Set(tile));
        }

        [Fact]
        public void OnClickLeft_UnitSelection_ClearUnitSelection()
        {
            var controller = GetFieldPanelController();

            var state = new ViewState { Camera = GenerateCamera(), Selection = mSelection };
            var e = new MouseEventArgs(MouseButtons.Left, 1, 50, 50, 0);

            GenerateCamera();

            controller.OnClick(state, e);

            mSelection.AssertWasCalled(_ => _.Clear());
        }

        [Fact]
        public void OnClickRight_UnitSelection_UseDefaultAction()
        {
            var controller = GetFieldPanelController();

            var selection = new Selection { Entity = new Entity() };
            var state = new ViewState { Camera = GenerateCamera(), Selection = selection };
            var e = new MouseEventArgs(MouseButtons.Right, 1, 50, 50, 0);

            controller.OnClick(state, e);

            mGameController.AssertWasCalled(_ =>
                _.UseDefaultAction(Arg<Entity>.Is.Anything, Arg<HexCoordinate>.Is.Anything));
        }
        /*
        [Fact]
        public void OnClickRight_NoUnitSelection_NoAction()
        {
            var controller = GetViewController();

            var state = new ViewState { Camera = GenerateCamera(), SelectedEntity = new Entity() };
            var e = new MouseEventArgs(MouseButtons.Right, 1, 50, 50, 0);

            controller.OnClick(state, e);

            mGameController.AssertWasNotCalled(_ =>
                _.UseDefaultAction(state));
        }*/

        private FieldPanelController GetFieldPanelController()
        {
            return new FieldPanelController(mAlgorithms, mGameController, mMap);
        }

        private Camera GenerateCamera()
        {
            return new Camera { Scale = 32, Location = XY.World(0, 0) };
        }
    }
}
