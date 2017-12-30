using System;
using System.Drawing;

namespace TBSG.Data.Hexmap
{
    public class Coordinate : IEquatable<Coordinate>
    {
        public int X { get; }
        public int Y { get; }

        public Coordinate(int pX, int pY)
        {
            X = pX;
            Y = pY;
        }

        public Point Point()
        {
            return new Point(X, Y);
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

            return (X == p.X) && (Y == p.Y);
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public override string ToString()
        {
            return "Coords(" + X + "," + Y + ")";
        }

        #endregion

        #region Overloads

        public bool Equals(Coordinate p)
        {
            if (p == null)
            {
                return false;
            }

            return (X == p.X) && (Y == p.Y);
        }

        public static Coordinate operator +(Coordinate c1, Coordinate c2)
        {
            return new Coordinate(c1.X + c2.X, c1.Y + c2.Y);
        }

        public static Coordinate operator -(Coordinate c1, Coordinate c2)
        {
            return new Coordinate(c1.X - c2.X, c1.Y - c2.Y);
        }

        public static Coordinate operator *(Coordinate c1, Coordinate c2)
        {
            return new Coordinate(c1.X * c2.X, c1.Y * c2.Y);
        }

        public static Coordinate operator /(Coordinate c1, Coordinate c2)
        {
            return new Coordinate(c1.X / c2.X, c1.Y / c2.Y);
        }

        #endregion
    }

    public static class XY
    {
        public static HexCoordinate Hex(int x, int y)
        {
            return new HexCoordinate(x, y);
        }

        public static WorldCoordinate World(int x, int y)
        {
            return new WorldCoordinate(x, y);
        }

        public static ScreenCoordinate Screen(int x, int y)
        {
            return new ScreenCoordinate(x, y);
        }

        public static HexCoordinate HexFromScreen
            (ScreenCoordinate coord, IAlgorithms algorithms, int scale, Coordinate location)
        {
            return algorithms.ScreenToHex(coord, scale, location);
        }

        public static HexCoordinate HexFromScreen
            (int x, int y, IAlgorithms algorithms, int scale, Coordinate location)
        {
            return algorithms.ScreenToHex(Screen(x, y), scale, location);
        }

        public static ScreenCoordinate ScreenFromHex
            (HexCoordinate coord, IAlgorithms algorithms, int scale, Coordinate location)
        {
            return algorithms.HexToScreen(coord, scale, location);
        }

        public static ScreenCoordinate ScreenFromHex
            (int x, int y, IAlgorithms algorithms, int scale, Coordinate location)
        {
            return algorithms.HexToScreen(Hex(x, y), scale, location);
        }
    }
}
