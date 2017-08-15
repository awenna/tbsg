using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TBSG.Data;

namespace TBSG
{
    public class Camera
    {
        public WorldCoordinate Location { get; set; }
        public ScreenCoordinate ViewSize { get; set; }
        public int Scale { get; set; }
    }
}
