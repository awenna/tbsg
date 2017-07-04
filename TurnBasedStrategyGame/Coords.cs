using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedStrategyGame
{
    public class Coords
    {
        public int x { get; }
        public int y { get; }

        public Coords(int pX, int pY)
        {
            x = pX;
            y = pY;
        }

        #region Overrides

        public override bool Equals(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Coords p = obj as Coords;
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

        public bool Equals(Coords p)
        {
            if (p == null)
            {
                return false;
            }

            return (x == p.x) && (y == p.y);
        }

        public static Coords operator +(Coords c1, Coords c2)
        {
            return new Coords(c1.x + c2.x, c1.y + c2.y);
        }

        public static Coords operator -(Coords c1, Coords c2)
        {
            return new Coords(c1.x - c2.x, c1.y - c2.y);
        }

        public static Coords operator *(Coords c1, Coords c2)
        {
            return new Coords(c1.x * c2.x, c1.y * c2.y);
        }

        public static Coords operator /(Coords c1, Coords c2)
        {
            return new Coords(c1.x / c2.x, c1.y / c2.y);
        }

        #endregion
    }
}
