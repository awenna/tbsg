using System.Drawing;
using System.Collections.Generic;
using TBSG.Data;
using TBSG.Model;

namespace TBSG.View
{
    public class Renderer : IRenderer
    {
        private readonly IAlgorithms mAlgorithms;
        private readonly IMap mMap;
        private readonly IConfigurationProvider mConfigurationProvider;

        public Renderer(IAlgorithms algorithms, IMap map, IConfigurationProvider configProvider)
        {
            mAlgorithms = algorithms;
            mMap = map;
            mConfigurationProvider = configProvider;
        }

        #region DrawGrid

        public void DrawGrid(IGraphics g, ICameraController controller)
        {
            var cameraLocation = controller.GetCamera().Location;
            var viewSize = controller.GetHexesInView();

            var viewStart = viewSize.Item1;
            var viewEnd = viewSize.Item2;

            var scale = controller.GetCamera().Scale;

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

                        g.FillPolygon(brush, hexagon);

                        brush.Dispose();

                        g.DrawPolygon(Pens.Black, hexagon);
                    }
                }
            }
        }

        #endregion

        #region DrawUnits

        public void DrawUnits(IGraphics g, ICameraController controller)
        {
            var cameraLocation = controller.GetCamera().Location;
            var viewSize = controller.GetHexesInView();

            var viewStart = viewSize.Item1;
            var viewEnd = viewSize.Item2;

            var scale = controller.GetCamera().Scale;

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

        #endregion

        #region DrawSelection

        public void DrawSelection(IGraphics g, ICameraController cameraController, ISelection selection)
        {
            if (!selection.Exists()) return;

            var camera = cameraController.GetCamera();
            var scale = camera.Scale;
            var cameraLocation = camera.Location;

            var pen = new Pen(Color.White);
            pen.Width = mConfigurationProvider.GetValue<int>("SelectionDrawWidth");

            var worldLocation = mAlgorithms.HexToWorld(selection.GetLocation(), scale);
            var screenCoordinate = mAlgorithms.WorldToScreen(worldLocation, cameraLocation);

            var hexagon = mAlgorithms.GetHexagon(screenCoordinate, scale);
            g.DrawPolygon(pen, hexagon);
        }

        #endregion
    }
}
