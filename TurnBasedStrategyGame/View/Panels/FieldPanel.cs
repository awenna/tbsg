﻿using System.Windows.Forms;
using TBSG.Data.Hexmap;
using TBSG.Data.View;

namespace TBSG.View.Panels
{
    public class FieldPanel : IPanelController
    {
        private readonly PictureBox mPanel;
        private readonly IViewController mViewController;
        private readonly IAlgorithms mAlgorithms; // Someone else's responsibility?
        private readonly IRenderer mRenderer;

        public FieldPanel(
            PictureBox panel,
            IViewController viewController,
            IAlgorithms algorithms,
            IRenderer renderer)
        {
            mPanel = panel;
            mViewController = viewController;
            mAlgorithms = algorithms;
            mRenderer = renderer;

            mPanel.TabIndex = 1;
            mPanel.Paint += new PaintEventHandler(Paint);
            mPanel.MouseDown += new MouseEventHandler(OnClick);
        }

        #region Public

        public void OnClick(object sender, MouseEventArgs e)
        {
            var state = mViewController.GetViewState();
            var clickHex = GetClickHex(state.Camera, XY.Screen(e.X, e.Y));
            
            switch (e.Button)
            {
                case MouseButtons.Left:
                    mViewController.SelectAt(state, clickHex);
                    break;
                case MouseButtons.Right:
                    mViewController.GetGameController()
                        .UseDefaultAction(state.Selection.GetEntity(), clickHex);
                    break;
            }
        }

        #endregion

        #region PanelFunctionality

        private void Paint(object sender, PaintEventArgs e)
        {
            var graphics = mViewController.GetGraphics(e);
            var camera = mViewController.GetCamera();

            mRenderer.DrawGrid(graphics, camera);
            mRenderer.DrawUnits(graphics, camera);
            mRenderer.DrawSelection(graphics, camera, mViewController.GetViewState().Selection);
        }

        #endregion

        #region Private

        private HexCoordinate GetClickHex(Camera camera, ScreenCoordinate coord)
        {
            return coord.ToHexCoordinate(mAlgorithms, camera.Scale, camera.Location);
        }

        #endregion
    }
}
