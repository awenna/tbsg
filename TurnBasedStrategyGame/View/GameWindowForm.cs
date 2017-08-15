using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TBSG.Data;
using TBSG.Control;

namespace TBSG.View
{
    public partial class GameWindowForm : Form
    {
        private readonly IAlgorithms mAlgorithms;
        private readonly IRenderer mRenderer;
        private readonly ICameraController mCameraController;
        private readonly IPanelController mFieldPanelController;
        private readonly IConfigurationProvider mConfigurationProvider;

        private ViewState viewState { get; set; }

        public GameWindowForm(
            IAlgorithms algorithms,
            IRenderer renderer,
            ICameraController cameraController,
            IPanelController fieldPanelController,
            IConfigurationProvider configProvider)
        {
            mAlgorithms = algorithms;
            mRenderer = renderer;
            mCameraController = cameraController;
            mFieldPanelController = fieldPanelController;
            mConfigurationProvider = configProvider;

            InitializeComponent();

            viewState = new ViewState { Camera = mCameraController.GetCamera() };
            var fieldSize = fieldPanel.Size;
            mCameraController.SetViewSize(XY.Screen(fieldSize.Width, fieldSize.Height));
        }

        public ViewState GetState()
        {
            return viewState;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            fieldPanel.Invalidate();
        }

        public void field_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var gw = new GraphicsWrapper(g);

            mRenderer.DrawGrid(gw, mCameraController);
            mRenderer.DrawUnits(gw, mCameraController);
            mRenderer.DrawSelection(gw, mCameraController, viewState.Selection);
        }

        public void GameWindowForm_KeyPress(object sender, KeyEventArgs e)
        {
            var scale = mCameraController.GetCamera().Scale;
            switch (e.KeyCode)
            {
                case Keys.W://Up:
                    mCameraController.MoveBy(new WorldCoordinate(0, -scale));
                    break;
                case Keys.S://Down:
                    mCameraController.MoveBy(new WorldCoordinate(0, scale));
                    break;
                case Keys.A://Left:
                    mCameraController.MoveBy(new WorldCoordinate(-scale, 0));
                    break;
                case Keys.D://Right:
                    mCameraController.MoveBy(new WorldCoordinate(scale, 0));
                    break;
            }
        }

        public void OnFieldPanelClick(object sender, MouseEventArgs e)
        {
            mFieldPanelController.OnClick(viewState, e);
        }
    }
}
