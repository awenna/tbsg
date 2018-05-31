using System.Collections.Generic;
using TBSG.Data;
using TBSG.Data.Hexmap;
using TBSG.Data.View;

namespace TBSG.View
{
    public interface ICameraController
    {
        Camera GetCamera();
        IEnumerable<HexCoord> GetHexesInView();
        void MoveBy(WorldCoord amount);
        void SetViewSize(ScreenCoord size);
    }
}
