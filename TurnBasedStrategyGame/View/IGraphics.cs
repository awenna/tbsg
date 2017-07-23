using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TBSG.View
{
    public interface IGraphics
    {
        void DrawPolygon(Pen pen, Point[] points);
        void FillPolygon(Brush brush, Point[] points);
        void DrawEllipse(Pen pen, Rectangle rect);
        void FillEllipse(Brush brush, Rectangle rect);
    }
}
