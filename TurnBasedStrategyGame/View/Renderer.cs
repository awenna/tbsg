using System.Drawing;
using TBSG.Data;
using TBSG.Model;

namespace TBSG.View
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

                        var brush = new SolidBrush(tile.TerrainType.DrawColor);

                        g.FillPolygon(brush, hexagon.Points);

                        brush.Dispose();

                        g.DrawPolygon(Pens.Black, hexagon.Points);
                    }
                }
            }
        }

        public void DrawUnits(IGraphics g, ICamera camera)
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
                        var unit = tile.Entity;
                        if (unit != null)
                        {
                            var hexLocation = mAlgorithms.HexToWorld(new HexCoordinate(x, y), scale);
                            var screenCoordinate = mAlgorithms.WorldToScreen(hexLocation, cameraLocation);

                            var drawCoordinate = screenCoordinate + new ScreenCoordinate(0, scale);

                            var brush = Brushes.DarkBlue;

                            var rectangle = new Rectangle(
                                drawCoordinate.x - scale/2,
                                drawCoordinate.y - scale/2,
                                scale, scale);

                            g.FillEllipse(brush, rectangle);
                            g.DrawEllipse(Pens.Black, rectangle);
                        }
                    }
                }
            }
        }
    }
}
