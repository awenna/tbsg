using System;
using System.Drawing;

namespace TBSG.Data.Hexmap
{
    [Serializable]
    public class TerrainType
    {
        public Color DrawColor { get; set; }

        public TerrainType(Color color)
        {
            DrawColor = color;
        }
    }
}
