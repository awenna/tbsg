using System.Drawing;
using System.Windows.Forms;
using TBSG.Control;
using TBSG.Data;
using TBSG.Data.Hexmap;
using TBSG.Data.View;
using TBSG.View.Panels;

namespace TBSG.View
{
    public class ViewController : IViewController
    {
        private ViewState mViewState { get; set; }
        
        private readonly IAlgorithms mAlgorithms;
        private readonly ICameraController mCameraController;
        private readonly IGameController mGameController;
        private readonly IRenderer mRenderer;

        public ViewController(
            IAlgorithms algorithms,
            ICameraController cameraController,
            IGameController gameController,
            IRenderer renderer)
        {
            mAlgorithms = algorithms;
            mCameraController = cameraController;
            mGameController = gameController;
            mRenderer = renderer;

            mViewState = new ViewState
            {
                Camera = mCameraController.GetCamera(),
                Selection = new Selection()
            };
        }

        public void SelectAt(ViewState state, HexCoordinate coord)
        {
            var map = mGameController.GetMap();

            state.Selection.Clear();

            var tile = map.TileAt(coord);
            state.Selection.Set(tile);
        }


        #region Getters

        public ViewState GetViewState()
        {
            return mViewState;
        }

        public ICameraController GetCamera()
        {
            return mCameraController;
        }

        public IGameController GetGameController()
        {
            return mGameController;
        }

        public GraphicsWrapper GetGraphics(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            return new GraphicsWrapper(g);
        }

        #endregion

        #region CreateControllers

        public FieldPanel CreateFieldPanel(PictureBox panel)
        {
            return new FieldPanel(
                panel,
                this,
                mAlgorithms,
                mRenderer);
        }

        public InfoPanel CreateInfoPanel(Panel panel)
        {
            return new InfoPanel(
                panel,
                this,
                mAlgorithms,
                mRenderer);
        }

        #endregion
    }
}
