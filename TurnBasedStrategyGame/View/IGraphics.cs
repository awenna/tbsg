using System.Drawing;
using TBSG.Data;
using TBSG.Data.Hexmap;

namespace TBSG.View
{
    public interface IGraphics
    {
        void DrawPolygon(Pen pen, Point[] points);
        void DrawPolygon(Pen pen, Hexagon hexagon);
        void FillPolygon(Brush brush, Point[] points);
        void FillPolygon(Brush brush, Hexagon hexagon);
        void DrawEllipse(Pen pen, Rectangle rect);
        void FillEllipse(Brush brush, Rectangle rect);
    }
}
