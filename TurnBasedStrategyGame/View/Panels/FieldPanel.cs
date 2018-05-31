using System.Windows.Forms;
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
            var map = mViewController.GetGameState().Map;

            mRenderer.DrawGrid(graphics, camera, map);
            mRenderer.DrawUnits(graphics, camera, map);
            mRenderer.DrawSelection(graphics, camera, mViewController.GetViewState().Selection, map);
        }

        #endregion

        #region Private

        private HexCoord GetClickHex(Camera camera, ScreenCoord coord)
        {
            return coord.ToHexCoord(mAlgorithms, camera.Scale, camera.Location);
        }

        #endregion
    }
}
