﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TBSG.Data;

namespace TBSG
{
    public interface ICamera
    {
        int GetScale();
        void SetSize(ScreenCoordinate size);
        void SetSize(Size size);
        WorldCoordinate GetLocation();
        Tuple<HexCoordinate, HexCoordinate> GetHexesInView();

        void MoveBy(WorldCoordinate amount);
    }
}
