using System.Drawing;
using TBSG.Data;

namespace TBSG.View.Drawing
{
    public class GridDrawer : IGridDrawer
    {
        public void DrawTile(
            IGraphics g,
            IAlgorithms algorithms,
            Tile tile,
            ScreenCoordinate screenCoordinate,
            int scale)
        {
            var hexagon = algorithms.GetHexagon(screenCoordinate, scale);

            var brush = new SolidBrush(tile.TerrainType.DrawColor);

            g.FillPolygon(brush, hexagon);

            brush.Dispose();

            g.DrawPolygon(Pens.Black, hexagon);
        }
    }
}
