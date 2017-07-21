using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TBSG
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public int x { get; }
        public int y { get; }

        public Coordinate(int pX, int pY)
        {
            x = pX;
            y = pY;
        }

        public Point Point()
        {
            return new Point(x, y);
        }

        #region Overrides

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Coordinate p = obj as Coordinate;
            if (p == null)
            {
                return false;
            }

            return (x == p.x) && (y == p.y);
        }

        public override int GetHashCode()
        {
            return x ^ y;
        }

        public override string ToString()
        {
            return "Coords(" + x + "," + y + ")";
        }

        #endregion

        #region Overloads

        public bool Equals(Coordinate p)
        {
            if (p == null)
            {
                return false;
            }

            return (x == p.x) && (y == p.y);
        }

        public static Coordinate operator +(Coordinate c1, Coordinate c2)
        {
            return new Coordinate(c1.x + c2.x, c1.y + c2.y);
        }

        public static Coordinate operator -(Coordinate c1, Coordinate c2)
        {
            return new Coordinate(c1.x - c2.x, c1.y - c2.y);
        }

        public static Coordinate operator *(Coordinate c1, Coordinate c2)
        {
            return new Coordinate(c1.x * c2.x, c1.y * c2.y);
        }

        public static Coordinate operator /(Coordinate c1, Coordinate c2)
        {
            return new Coordinate(c1.x / c2.x, c1.y / c2.y);
        }

        #endregion
    }
}
