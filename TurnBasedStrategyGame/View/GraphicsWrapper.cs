using System.Drawing;
using TBSG.Data;
using TBSG.Data.Hexmap;

namespace TBSG.View
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

        public void DrawPolygon(Pen pen, Hexagon hexagon)
        {
            mGraphics.DrawPolygon(pen, hexagon.Points);
        }

        public void FillPolygon(Brush brush, Point[] points)
        {
            mGraphics.FillPolygon(brush, points);
        }

        public void FillPolygon(Brush brush, Hexagon hexagon)
        {
            mGraphics.FillPolygon(brush, hexagon.Points);
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
