using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Data;
using TBSG.View.Forms;

namespace TBSG.View
{
    public class ViewController : IViewController
    {
        private ViewState mViewState { get; set; }

        private readonly GameWindowForm mGameWindowForm;
        private readonly ICameraController mCameraController;
        private readonly IRenderer mRenderer;

        public ViewController(
            GameWindowForm gameWindowForm,
            ICameraController cameraController,
            IRenderer renderer)
        {
            mGameWindowForm = gameWindowForm;
            mCameraController = cameraController;
            mRenderer = renderer;
        }

        public ViewState GetViewState()
        {
            return mViewState;
        }
    }
}
