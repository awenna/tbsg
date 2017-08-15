using System;
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

namespace TBSG.View
{
    public class FieldPanelControllerTests
    {
        private readonly IAlgorithms mAlgorithms;
        private readonly IGameController mGameController;

        public FieldPanelControllerTests()
        {
            mAlgorithms = new Algorithms();
            mGameController = MockRepository.GenerateMock<IGameController>();
        }

        [Fact]
        public void OnClickLeft_NoTileSelection_CreateTileSelection()
        {
            var controller = GetViewController();

            var state = new ViewState { Camera = GenerateCamera() };
            var e = new MouseEventArgs(MouseButtons.Left, 1, 50, 50, 0);

            

            controller.OnClick(state, e);

            Assert.NotNull(state.Selection);
        }

        [Fact]
        public void OnClickLeft_UnitSelection_ClearUnitSelection()
        {
            var controller = GetViewController();

            var state = new ViewState { Camera = GenerateCamera(), SelectedEntity = new Entity() };
            var e = new MouseEventArgs(MouseButtons.Left, 1, 50, 50, 0);

            GenerateCamera();

            controller.OnClick(state, e);

            Assert.Null(state.SelectedEntity);
        }

        [Fact]
        public void OnClickRight_UnitSelection_UseDefaultAction()
        {
            var controller = GetViewController();

            var state = new ViewState { Camera = GenerateCamera(), SelectedEntity = new Entity() };
            var e = new MouseEventArgs(MouseButtons.Right, 1, 50, 50, 0);

            controller.OnClick(state, e);

            mGameController.AssertWasCalled(_ =>
                _.UseDefaultAction(state));
        }

        private FieldPanelController GetViewController()
        {
            return new FieldPanelController(mAlgorithms, mGameController);
        }

        private Camera GenerateCamera()
        {
            return new Camera { Scale = 32, Location = XY.World(0, 0) };
        }
    }
}
