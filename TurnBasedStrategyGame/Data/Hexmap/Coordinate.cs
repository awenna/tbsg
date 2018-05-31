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
        public static HexCoord Hex(int x, int y)
        {
            return new HexCoord(x, y);
        }

        public static WorldCoord World(int x, int y)
        {
            return new WorldCoord(x, y);
        }

        public static ScreenCoord Screen(int x, int y)
        {
            return new ScreenCoord(x, y);
        }

        public static CubeCoord Cube(int x, int y)
        {
            return new CubeCoord(x, y);
        }

        public static HexCoord HexFromScreen
            (ScreenCoord coord, IAlgorithms algorithms, int scale, Coordinate location)
        {
            return algorithms.ScreenToHex(coord, scale, location);
        }

        public static HexCoord HexFromScreen
            (int x, int y, IAlgorithms algorithms, int scale, Coordinate location)
        {
            return algorithms.ScreenToHex(Screen(x, y), scale, location);
        }

        public static ScreenCoord ScreenFromHex
            (HexCoord coord, IAlgorithms algorithms, int scale, Coordinate location)
        {
            return algorithms.HexToScreen(coord, scale, location);
        }

        public static ScreenCoord ScreenFromHex
            (int x, int y, IAlgorithms algorithms, int scale, Coordinate location)
        {
            return algorithms.HexToScreen(Hex(x, y), scale, location);
        }
    }
}
