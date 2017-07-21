using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using TBSG.Data;

namespace TBSG
{
    public class Renderer : IRenderer
    {
        private readonly IAlgorithms mAlgorithms;
        private readonly IMap mMap;

        public Renderer(IAlgorithms algorithms, IMap map)
        {
            mAlgorithms = algorithms;
            mMap = map;
        }

        public void DrawGrid(IGraphics g, ICamera camera)
        {
            var cameraLocation = camera.GetLocation();
            var viewSize = camera.GetHexesInView();

            var viewStart = viewSize.Item1;
            var viewEnd = viewSize.Item2;

            var scale = camera.GetScale();

            for (int x = viewStart.x -1 ; x <= viewEnd.x + 1; x++)
            {
                for (int y = viewStart.y -1 ; y <= viewEnd.y + 1; y++)
                {
                    var tile = mMap.TileAt(new HexCoordinate(x, y));
                    if (tile != null)
                    {
                        var hexLocation = mAlgorithms.HexToWorld(new HexCoordinate(x, y), scale);
                        var screenCoordinate = mAlgorithms.WorldToScreen(hexLocation, cameraLocation);
                        var hexagon = mAlgorithms.GetHexagon(screenCoordinate, scale);

                        g.DrawPolygon(Pens.Black, hexagon.Points);
                    }
                }
            }
        }

        public void DrawTiles(IGraphics g, ICamera camera)
        {
            var cameraLocation = camera.GetLocation();
            var viewSize = camera.GetHexesInView();

            var viewStart = viewSize.Item1;
            var viewEnd = viewSize.Item2;

            var scale = camera.GetScale();

            for (int x = viewStart.x - 1; x <= viewEnd.x + 1; x++)
            {
                for (int y = viewStart.y - 1; y <= viewEnd.y + 1; y++)
                {
                    var tile = mMap.TileAt(new HexCoordinate(x, y));
                    if (tile != null)
                    {
                        var hexLocation = mAlgorithms.HexToWorld(new HexCoordinate(x, y), scale);
                        var screenCoordinate = mAlgorithms.WorldToScreen(hexLocation, cameraLocation);
                        var hexagon = mAlgorithms.GetHexagon(screenCoordinate, scale);

                        var brush = new SolidBrush(tile.TerrainType.DrawColor);

                        g.FillPolygon(brush, hexagon.Points);

                        brush.Dispose();
                    }
                }
            }
        }
    }
}
