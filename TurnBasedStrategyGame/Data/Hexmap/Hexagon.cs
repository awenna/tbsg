using System;
using System.Drawing;

namespace TBSG.Data.Hexmap
{
    public class Hexagon : IEquatable<Hexagon>
    {
        public Point[] Points { get; private set; }

        public Hexagon(Point[] points)
        {
            Points = points;
        }

        #region Overrides

        public override int GetHashCode()
        {
            return Points.GetHashCode();
        }

        #endregion

        #region Overloads

        public bool Equals(Hexagon other)
        {
            if (other == null)
            {
                return false;
            }

            return Points.Equals(other.Points);
        }

        #endregion
    }
}
