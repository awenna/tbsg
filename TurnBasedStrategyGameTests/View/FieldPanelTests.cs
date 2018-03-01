using System.Windows.Forms;
using Microsoft.Win32;
using Rhino.Mocks;
using Xunit;
using TBSG.Control;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Data.View;
using TBSG.Model.Hexmap;
using TBSG.View.Panels;

namespace TBSG.View
{
    public class FieldPanelTests
    {
        private readonly IViewController mViewController;
        private readonly IAlgorithms mAlgorithms;
        private readonly IRenderer mRenderer;
        private readonly ISelection mSelection;

        public FieldPanelTests()
        {
            mAlgorithms = new Algorithms();
            mViewController = MockRepository.GenerateMock<IViewController>();
            mRenderer = MockRepository.GenerateMock<IRenderer>();
            mSelection = MockRepository.GenerateStub<ISelection>();
        }

        [Fact]
        public void OnClickLeft_SelectAtHex()
        {
            var fieldPanel = GetFieldPanel();

            var state = new ViewState { Camera = GenerateCamera(), Selection = mSelection };
            var e = new MouseEventArgs(MouseButtons.Left, 1, 50, 50, 0);

            mViewController.Stub(_ => _.GetViewState()).Return(state);

            fieldPanel.OnClick(new object(), e);

            mViewController.AssertWasCalled(_ => 
                _.SelectAt(Arg<ViewState>.Is.Equal(state), Arg<HexCoordinate>.Is.Anything));
        }

        [Fact]
        public void OnClickRight_UnitSelection_UseDefaultAction()
        {
            var fieldPanel = GetFieldPanel();

            var gameController = MockRepository.GenerateMock<IGameController>();

            var selection = new Selection { Entity = new Entity() };
            var state = new ViewState { Camera = GenerateCamera(), Selection = selection };
            var e = new MouseEventArgs(MouseButtons.Right, 1, 50, 50, 0);

            mViewController.Stub(_ => _.GetViewState()).Return(state);
            mViewController.Stub(_ => _.GetGameController())
                .Return(gameController);

            fieldPanel.OnClick(state, e);

            gameController.AssertWasCalled(_ => 
            _.UseDefaultAction(Arg<Entity>.Is.Anything, Arg<HexCoordinate>.Is.Anything));
        }

        private FieldPanel GetFieldPanel()
        {
            return new FieldPanel(new PictureBox(), mViewController, mAlgorithms, mRenderer);
        }

        private Camera GenerateCamera()
        {
            return new Camera { Scale = 32, Location = XY.World(0, 0) };
        }
    }
}
