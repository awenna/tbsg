using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Data;
using TBSG.Data.Hexmap;

namespace TBSG.View.Drawing
{
    public interface IGridDrawer
    {
        void DrawTile(
            IGraphics g,
            IAlgorithms algorithms,
            Tile tile,
            ScreenCoordinate screenCoordinate,
            int scale);
    }
}
