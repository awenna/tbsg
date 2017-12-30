using System.Drawing;

namespace TBSG.Data.Hexmap
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
