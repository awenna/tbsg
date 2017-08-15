using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TBSG.Data;
using TBSG.Control;

namespace TBSG.View
{
    public class FieldPanelController : IPanelController
    {
        private readonly IAlgorithms mAlgorithms;
        private readonly IGameController mGameController;

        public FieldPanelController(IAlgorithms algorithms, IGameController gameController)
        {
            mAlgorithms = algorithms;
            mGameController = gameController;
        }

        public void OnClick(ViewState state, MouseEventArgs e)
        {
            var clickCoord = XY.Screen(e.X, e.Y);

            switch (e.Button)
            {
                case MouseButtons.Left:
                    SelectTileAt(state, clickCoord);
                    break;
                case MouseButtons.Right:
                    mGameController.UseDefaultAction(state);
                    break;
            }
            
        }

        private void SelectTileAt(ViewState state, ScreenCoordinate coord)
        {
            var camera = state.Camera;
            var hexCoordinate = coord.ToHexCoordinate(mAlgorithms, camera.Scale, camera.Location);
            state.Selection = new[] { hexCoordinate };
            state.SelectedEntity = null;
        }
    }
}
