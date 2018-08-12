using System;
using System.Collections.Generic;

namespace TBSG.Data.Hexmap
{
    [Serializable]
    public class HexCoord : Coordinate
    {
        public HexCoord(int pX, int pY) : base(pX, pY) { }

        public WorldCoord ToWorldCoord(IAlgorithms algorithms, int scale)
        {
            return algorithms.HexToWorld(this, scale);
        }

        public ScreenCoord ToScreenCoord(IAlgorithms algorithms, int scale, Coordinate location)
        {
            return algorithms.HexToScreen(this, scale, location);
        }

        public CubeCoord ToCubeCoord()
        {
            return new CubeCoord(X - (Y - (Y & 1)) / 2, Y);
        }

        public List<HexCoord> Neighbours()
        {
            if (Y % 2 == 0)
            {
                return new List<HexCoord>
                {
                    XY.Hex( 0, -1) + this,
                    XY.Hex(+1,  0) + this,
                    XY.Hex( 0, +1) + this,
                    XY.Hex(-1, +1) + this,
                    XY.Hex(-1,  0) + this,
                    XY.Hex(-1, -1) + this
                };
            }
            else
            {
                return new List<HexCoord>
                {
                    XY.Hex(+1, -1) + this,
                    XY.Hex(+1,  0) + this,
                    XY.Hex(+1, +1) + this,
                    XY.Hex( 0, +1) + this,
                    XY.Hex(-1,  0) + this,
                    XY.Hex( 0, -1) + this
                };
            }
        }

        #region HexCoord Overrides

        public static HexCoord operator +(HexCoord c1, HexCoord c2)
        {
            return new HexCoord(c1.X + c2.X, c1.Y + c2.Y);
        }

        public static HexCoord operator -(HexCoord c1, HexCoord c2)
        {
            return new HexCoord(c1.X - c2.X, c1.Y - c2.Y);
        }

        public static HexCoord operator *(HexCoord c1, HexCoord c2)
        {
            return new HexCoord(c1.X * c2.X, c1.Y * c2.Y);
        }

        public static HexCoord operator /(HexCoord c1, HexCoord c2)
        {
            return new HexCoord(c1.X / c2.X, c1.Y / c2.Y);
        }

        #endregion
    }

    [Serializable]
    public class WorldCoord : Coordinate
    {
        public WorldCoord(int pX, int pY) : base(pX, pY) { }

        public HexCoord ToHexCoordinate(IAlgorithms algorithms, int scale)
        {
            return algorithms.WorldToHex(this, scale);
        }

        public ScreenCoord ToScreenCoordinate(IAlgorithms algorithms, Coordinate location)
        {
            return algorithms.WorldToScreen(this, location);
        }

        #region HexCoord Overrides

        public static WorldCoord operator +(WorldCoord c1, WorldCoord c2)
        {
            return new WorldCoord(c1.X + c2.X, c1.Y + c2.Y);
        }

        public static WorldCoord operator -(WorldCoord c1, WorldCoord c2)
        {
            return new WorldCoord(c1.X - c2.X, c1.Y - c2.Y);
        }

        public static WorldCoord operator *(WorldCoord c1, WorldCoord c2)
        {
            return new WorldCoord(c1.X * c2.X, c1.Y * c2.Y);
        }

        public static WorldCoord operator /(WorldCoord c1, WorldCoord c2)
        {
            return new WorldCoord(c1.X / c2.X, c1.Y / c2.Y);
        }

        #endregion
    }

    public class ScreenCoord : Coordinate
    {
        public ScreenCoord(int pX, int pY) : base(pX, pY) { }

        public WorldCoord ToWorldCoord(IAlgorithms algorithms, Coordinate location)
        {
            return algorithms.ScreenToWorld(this, location);
        }

        public HexCoord ToHexCoord(IAlgorithms algorithms, int scale, Coordinate location)
        {
            return algorithms.ScreenToHex(this, scale, location);
        }

        #region HexCoord Overrides

        public static ScreenCoord operator +(ScreenCoord c1, ScreenCoord c2)
        {
            return new ScreenCoord(c1.X + c2.X, c1.Y + c2.Y);
        }

        public static ScreenCoord operator -(ScreenCoord c1, ScreenCoord c2)
        {
            return new ScreenCoord(c1.X - c2.X, c1.Y - c2.Y);
        }

        public static ScreenCoord operator *(ScreenCoord c1, ScreenCoord c2)
        {
            return new ScreenCoord(c1.X * c2.X, c1.Y * c2.Y);
        }

        public static ScreenCoord operator /(ScreenCoord c1, ScreenCoord c2)
        {
            return new ScreenCoord(c1.X / c2.X, c1.Y / c2.Y);
        }

        #endregion
    }

    public class CubeCoord : Coordinate
    {
        public int Z;

        public CubeCoord(int pX, int pY) : base(pX, pY)
        {
            Z = -pX - pY;
        }

        public HexCoord ToHexCoordinate()
        {
            return XY.Hex(X + (Y - (Y & 1)) / 2, Y);
        }
    }

}
