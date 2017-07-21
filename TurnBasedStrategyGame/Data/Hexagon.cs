using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TBSG.Data
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
