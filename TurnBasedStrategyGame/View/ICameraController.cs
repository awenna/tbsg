using System.Collections.Generic;
using TBSG.Data;
using TBSG.Data.Hexmap;
using TBSG.Data.View;

namespace TBSG.View
{
    public interface ICameraController
    {
        Camera GetCamera();
        IEnumerable<HexCoordinate> GetHexesInView();
        void MoveBy(WorldCoordinate amount);
        void SetViewSize(ScreenCoordinate size);
    }
}
