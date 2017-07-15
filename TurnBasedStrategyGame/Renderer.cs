using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TurnBasedStrategyGame
{
    public class Renderer : IRenderer
    {
        private readonly IAlgorithms mAlgorithms;

        public Renderer(IAlgorithms algorithms)
        {
            mAlgorithms = algorithms;
        }

        public void DrawGrid(IGraphics g, ICamera camera)
        {
            var cameraLocation = camera.GetLocation();
            var viewSize = camera.GetHexesInView();


            for (int x = 0; x < viewSize.x; x++)
            {
                for (int y = 0; y < viewSize.y; y++)
                {
                    var hexLocation = mAlgorithms.GetGridToWorldCoordinate(new HexCoordinate(x, y), 32);
                    var hexagon = mAlgorithms.GetHexagon(hexLocation, 32);
                    
                    g.FillPolygon(Brushes.Black, hexagon.Points);
                    g.DrawPolygon(Pens.Green, hexagon.Points);
                }
            }
        }
    }
}
