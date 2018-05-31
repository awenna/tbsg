using System.Drawing;
using TBSG.Data;
using TBSG.Data.Hexmap;

namespace TBSG.View.Drawing
{
    public class GridDrawer : IGridDrawer
    {
        public void DrawTile(
            IGraphics g,
            IAlgorithms algorithms,
            Tile tile,
            ScreenCoord screenCoord,
            int scale)
        {
            var hexagon = algorithms.GetHexagon(screenCoord, scale);

            var brush = new SolidBrush(tile.TerrainType.DrawColor);

            g.FillPolygon(brush, hexagon);

            brush.Dispose();

            g.DrawPolygon(Pens.Black, hexagon);
        }
    }
}
