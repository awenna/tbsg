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

        public WorldCoordinate ToWorldCoordinate()
        {
            throw new NotImplementedException();
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

        public HexCoordinate ToHexCoordinate()
        {
            throw new NotImplementedException();
        }

        public ScreenCoordinate ToScreenCoordinate()
        {
            throw new NotImplementedException();
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

        public WorldCoordinate ToWorldCoordinate()
        {
            throw new NotImplementedException();
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
