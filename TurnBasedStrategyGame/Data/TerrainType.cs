using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TBSG.Data
{
    public class TerrainType
    {
        public Color DrawColor { get; set; }

        public TerrainType(Color color)
        {
            DrawColor = color;
        }
    }
}
