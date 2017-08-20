using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TBSG.Data;
using TBSG.Model;
using TBSG.Control;

namespace TBSG.View
{
    public class FieldPanelController : IPanelController
    {
        private readonly IAlgorithms mAlgorithms;
        private readonly IGameController mGameController;
        private readonly IMap mMap;

        public FieldPanelController(
            IAlgorithms algorithms,
            IGameController gameController,
            IMap map)
        {
            mAlgorithms = algorithms;
            mGameController = gameController;
            mMap = map;
        }

        public void OnClick(ViewState state, MouseEventArgs e)
        {
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
    }
}
