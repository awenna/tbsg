using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TBSG.Data;

namespace TBSG.View
{
    public interface ICameraController
    {
        Camera GetCamera();
        Tuple<HexCoordinate, HexCoordinate> GetHexesInView();
        void MoveBy(WorldCoordinate amount);
        void SetViewSize(ScreenCoordinate size);
    }
}
