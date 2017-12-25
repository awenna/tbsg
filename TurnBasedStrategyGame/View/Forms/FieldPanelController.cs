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
        private readonly GameWindowForm mGameWindowForm; // Changes
        private readonly IAlgorithms mAlgorithms; // Someone else's responsibility?
        private readonly ICameraController mCameraController; //ViewControl
        private readonly IRenderer mRenderer; 
        private readonly IGameController mGameController;
        private readonly IMap mMap; // ViewControl

        public FieldPanelController(
            PictureBox panel,
            GameWindowForm gameWindowForm,
            IAlgorithms algorithms,
            ICameraController cameraController,
            IRenderer renderer,
            IGameController gameController,
            IMap map)
        {
            mPanel = panel;
            mGameWindowForm = gameWindowForm;
            mAlgorithms = algorithms;
            mCameraController = cameraController;
            mRenderer = renderer;
            mGameController = gameController;
            mMap = map;

            mPanel.TabIndex = 1;
            mPanel.Paint += new PaintEventHandler(Paint);
            mPanel.MouseDown += new MouseEventHandler(OnClick);
        }

        #region Public

        public void OnClick(object sender, MouseEventArgs e)
        {
            var state = mGameWindowForm.viewState;
            var clickHex = GetClickHex(state.Camera, XY.Screen(e.X, e.Y));
            
            switch (e.Button)
            {
                case MouseButtons.Left:
                    SelectAt(state, clickHex);
                    break;
                case MouseButtons.Right:
                    mGameController.UseDefaultAction(state.Selection.GetEntity(), clickHex);
                    break;
            }
        }

        public void Paint(object sender, PaintEventArgs e)
        {
            var graphics = GetGraphics(e);

            mRenderer.DrawGrid(graphics, mCameraController);
            mRenderer.DrawUnits(graphics, mCameraController);
            mRenderer.DrawSelection(graphics, mCameraController, mGameWindowForm.viewState.Selection);
        }

        #endregion

        #region Private

        // Move to ViewController
        private void SelectAt(ViewState state, HexCoordinate coord)
        {
            state.Selection.Clear();
            var tile = mMap.TileAt(coord);
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
