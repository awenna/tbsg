using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TurnBasedStrategyGame
{
    public interface IGraphics
    {
        void DrawPolygon(Pen pen, Point[] points);
        void FillPolygon(Brush brush, Point[] points);
    }
}
