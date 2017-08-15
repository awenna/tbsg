using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBSG.Data
{
    public class HexCoordinate : Coordinate
    {
        public HexCoordinate(int pX, int pY) : base(pX, pY) { }

        public WorldCoordinate ToWorldCoordinate(IAlgorithms algorithms, int scale)
        {
            return algorithms.HexToWorld(this, scale);
        }

        public ScreenCoordinate ToScreenCoordinate(IAlgorithms algorithms, int scale, Coordinate location)
        {
            return algorithms.HexToScreen(this, scale, location);
        }

        #region HexCoordinate Overrides

        public static HexCoordinate operator +(HexCoordinate c1, HexCoordinate c2)
        {
            return new HexCoordinate(c1.x + c2.x, c1.y + c2.y);
        }

        public static HexCoordinate operator -(HexCoordinate c1, HexCoordinate c2)
        {
            return new HexCoordinate(c1.x - c2.x, c1.y - c2.y);
        }

        public static HexCoordinate operator *(HexCoordinate c1, HexCoordinate c2)
        {
            return new HexCoordinate(c1.x * c2.x, c1.y * c2.y);
        }

        public static HexCoordinate operator /(HexCoordinate c1, HexCoordinate c2)
        {
            return new HexCoordinate(c1.x / c2.x, c1.y / c2.y);
        }

        #endregion
    }

    public class WorldCoordinate : Coordinate
    {
        public WorldCoordinate(int pX, int pY) : base(pX, pY) { }

        public HexCoordinate ToHexCoordinate(IAlgorithms algorithms, int scale)
        {
            return algorithms.WorldToHex(this, scale);
        }

        public ScreenCoordinate ToScreenCoordinate(IAlgorithms algorithms, Coordinate location)
        {
            return algorithms.WorldToScreen(this, location);
        }

        #region HexCoordinate Overrides

        public static WorldCoordinate operator +(WorldCoordinate c1, WorldCoordinate c2)
        {
            return new WorldCoordinate(c1.x + c2.x, c1.y + c2.y);
        }

        public static WorldCoordinate operator -(WorldCoordinate c1, WorldCoordinate c2)
        {
            return new WorldCoordinate(c1.x - c2.x, c1.y - c2.y);
        }

        public static WorldCoordinate operator *(WorldCoordinate c1, WorldCoordinate c2)
        {
            return new WorldCoordinate(c1.x * c2.x, c1.y * c2.y);
        }

        public static WorldCoordinate operator /(WorldCoordinate c1, WorldCoordinate c2)
        {
            return new WorldCoordinate(c1.x / c2.x, c1.y / c2.y);
        }

        #endregion
    }

    public class ScreenCoordinate : Coordinate
    {
        public ScreenCoordinate(int pX, int pY) : base(pX, pY) { }

        public WorldCoordinate ToWorldCoordinate(IAlgorithms algorithms, Coordinate location)
        {
            return algorithms.ScreenToWorld(this, location);
        }

        public HexCoordinate ToHexCoordinate(IAlgorithms algorithms, int scale, Coordinate location)
        {
            return algorithms.ScreenToHex(this, scale, location);
        }

        #region HexCoordinate Overrides

        public static ScreenCoordinate operator +(ScreenCoordinate c1, ScreenCoordinate c2)
        {
            return new ScreenCoordinate(c1.x + c2.x, c1.y + c2.y);
        }

        public static ScreenCoordinate operator -(ScreenCoordinate c1, ScreenCoordinate c2)
        {
            return new ScreenCoordinate(c1.x - c2.x, c1.y - c2.y);
        }

        public static ScreenCoordinate operator *(ScreenCoordinate c1, ScreenCoordinate c2)
        {
            return new ScreenCoordinate(c1.x * c2.x, c1.y * c2.y);
        }

        public static ScreenCoordinate operator /(ScreenCoordinate c1, ScreenCoordinate c2)
        {
            return new ScreenCoordinate(c1.x / c2.x, c1.y / c2.y);
        }

        #endregion
    }



}
