using System.Drawing;
using System.Windows.Forms;
using TBSG.Control;
using TBSG.Data;
using TBSG.Model;

namespace TBSG.View.Forms
{
    public class FieldPanelController : IPanelController
    {
        private readonly PictureBox mPanel;
        private readonly IViewController mViewController; // Changes
        private readonly IAlgorithms mAlgorithms; // Someone else's responsibility?
        private readonly IRenderer mRenderer;

        public FieldPanelController(
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
                    SelectAt(state, clickHex);
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
            var graphics = GetGraphics(e);
            var camera = mViewController.GetCamera();

            mRenderer.DrawGrid(graphics, camera);
            mRenderer.DrawUnits(graphics, camera);
            mRenderer.DrawSelection(graphics, camera, mViewController.GetViewState().Selection);
        }

        #endregion

        #region Private

        // Move to ViewController
        private void SelectAt(ViewState state, HexCoordinate coord)
        {
            var map = mViewController.GetGameController().GetMap();

            state.Selection.Clear();

            var tile = map.TileAt(coord);
            state.Selection.Set(tile);
        }

        private HexCoordinate GetClickHex(Camera camera, ScreenCoordinate coord)
        {
            return coord.ToHexCoordinate(mAlgorithms, camera.Scale, camera.Location);
        }
        
        //Move under ViewController?????
        private GraphicsWrapper GetGraphics(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            return new GraphicsWrapper(g);
        }

        #endregion
    }
}
