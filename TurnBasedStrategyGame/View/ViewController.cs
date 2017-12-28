using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TBSG.Control;
using TBSG.Data;
using TBSG.Model;
using TBSG.View.Forms;

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

        #endregion

        public FieldPanelController CreateFieldPanelController(PictureBox panel)
        {
            return new FieldPanelController(
                panel,
                this,
                mAlgorithms,
                mRenderer);
        }
    }
}
