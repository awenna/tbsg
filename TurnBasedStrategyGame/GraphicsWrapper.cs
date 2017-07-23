using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TBSG
{
    public class GraphicsWrapper : IGraphics
    {
        private readonly Graphics mGraphics;

        public GraphicsWrapper(Graphics g)
        {
            mGraphics = g;
        }

        public void DrawPolygon(Pen pen, Point[] points)
        {
            mGraphics.DrawPolygon(pen, points);
        }

        public void FillPolygon(Brush brush, Point[] points)
        {
            mGraphics.FillPolygon(brush, points);
        }

        public void DrawEllipse(Pen pen, Rectangle rect)
        {
            mGraphics.DrawEllipse(pen, rect);
        }

        public void FillEllipse(Brush brush, Rectangle rect)
        {
            mGraphics.FillEllipse(brush, rect);
        }
    }
}
