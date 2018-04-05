using System.Drawing;
using TBSG.Data.Hexmap;
using TBSG.Data.View;
using TBSG.Model.Hexmap;
using TBSG.View.Drawing;

namespace TBSG.View
{
    public class Renderer : IRenderer
    {
        private readonly IAlgorithms mAlgorithms;
        private readonly IGridDrawer mGridDrawer;
        private readonly IConfigurationProvider mConfigurationProvider;

        public Renderer(
            IAlgorithms algorithms,
            IGridDrawer gridDrawer,
            IConfigurationProvider configProvider)
        {
            mAlgorithms = algorithms;
            mGridDrawer = gridDrawer;
            mConfigurationProvider = configProvider;
        }

        #region DrawGrid

        public void DrawGrid(
            IGraphics g, ICameraController controller, IMap map)
        {
            var hexesInView = controller.GetHexesInView();

            var scale = controller.GetCamera().Scale;

            foreach(var hex in hexesInView)
            {
                var tile = map.TileAt(hex);
                if (tile != null)
                {
                    var screenCoordinate = XY.ScreenFromHex(hex, mAlgorithms, scale, controller.GetCamera().Location);
                    mGridDrawer.DrawTile(g, mAlgorithms, tile, screenCoordinate, scale);
                }
            }
        }

        #endregion

        #region DrawUnits

        public void DrawUnits(IGraphics g, ICameraController controller, IMap map)
        {
            var cameraLocation = controller.GetCamera().Location;
            var hexesInView = controller.GetHexesInView();

            var scale = controller.GetCamera().Scale;

            foreach (var hex in hexesInView)
            {
                var entity = map.EntityAt(hex);
                if (entity != null)
                {
                    var hexLocation = mAlgorithms.HexToWorld(hex, scale);
                    var screenCoordinate = mAlgorithms.WorldToScreen(hexLocation, cameraLocation);

                    var drawCoordinate = screenCoordinate + XY.Screen(0, scale);

                    var brush = Brushes.DarkBlue;

                    var rectangle = new Rectangle(
                        drawCoordinate.X - scale/2,
                        drawCoordinate.Y - scale/2,
                        scale, scale);

                    g.FillEllipse(brush, rectangle);
                    g.DrawEllipse(Pens.Black, rectangle);
                }
            }
        }

        #endregion

        #region DrawSelection

        public void DrawSelection(
            IGraphics g, ICameraController cameraController, ISelection selection, IMap map)
        {
            if (!selection.Exists()) return;

            var camera = cameraController.GetCamera();
            var scale = camera.Scale;
            var cameraLocation = camera.Location;

            var pen = new Pen(Color.White);
            pen.Width = mConfigurationProvider.GetValue<int>("SelectionDrawWidth");

            var location = map.LocationOf(selection);

            var worldLocation = mAlgorithms.HexToWorld(location, scale);
            var screenCoordinate = mAlgorithms.WorldToScreen(worldLocation, cameraLocation);

            var hexagon = mAlgorithms.GetHexagon(screenCoordinate, scale);
            g.DrawPolygon(pen, hexagon);
        }

        #endregion

        public void DrawMinimap(
            IGraphics g,
            ScreenCoordinate size,
            ICameraController cameraController)
        {

        }

        #region 

        public void DrawInfoGraphics(IGraphics g, ScreenCoordinate size)
        {
            g.DrawEllipse(Pens.DarkMagenta, new Rectangle(0, 0, 50, 50));
        }

        #endregion
    }
}
