using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using TBSG.Data.Hexmap;

namespace TBSG
{
    public class Algorithms : IAlgorithms
    {

        #region HexToWorld

        public WorldCoordinate HexToWorld(HexCoordinate coords, int scale)
        {
            var cpl = Math.Cos(Math.PI / 6) * scale;
            var spl = 0.5d * scale;

            int x, y;

            if (coords.Y % 2 == 0)
            {
                x = (int)Math.Round((cpl * (2 * coords.X + 1)));
                y = (int)(3 * coords.Y * scale / 2);
            }
            else
            {
                x = (int)Math.Round((2 * cpl * (coords.X + 1)));
                y = (int)Math.Round((spl + scale + 3 * (coords.Y - 1) * scale / 2));
            }

            return new WorldCoordinate(x, y);
        }

        #endregion

        #region WorldToHex

        public HexCoordinate WorldToHex(WorldCoordinate coords, int scale)
        {
            var cpl = Math.Cos(Math.PI / 6) * scale;
            var spl = 0.5d * scale;

            double gridHeight = 2 * scale - spl;
            double gridWidth = 2 * scale * Math.Cos(Math.PI / 6);

            int row = (int)(coords.Y / gridHeight);
            int column;
            if (row % 2 == 0)
                column = (int)(coords.X / gridWidth);
            else
                column = (int)((coords.X - gridWidth / 2) / gridWidth);

            double relY = coords.Y - row * gridHeight;
            double relX;
            if (row % 2 == 0)
                relX = coords.X - column * gridWidth;
            else
                relX = coords.X - (column * gridWidth) - gridWidth / 2;

            var c = scale / 2;
            var m = c / (gridWidth / 2);

            if (relY < (-m * relX) + c)
            {
                row--;
                if (row % 2 == 1) column--;
            }
            else if (relY < (m * relX) - c)
            {
                row--;
                if (row % 2 == 0) column++;
            }
            
            return new HexCoordinate(column, row);
        }

        #endregion

        #region WorldToScreen

        public ScreenCoordinate WorldToScreen(WorldCoordinate coords, Coordinate location)
        {
            return new ScreenCoordinate(coords.X - location.X, coords.Y - location.Y);
        }

        #endregion

        #region ScreenToWorld

        public WorldCoordinate ScreenToWorld(ScreenCoordinate coords, Coordinate location)
        {
            return new WorldCoordinate(coords.X + location.X, coords.Y + location.Y);
        }

        #endregion

        #region HexToScreen

        public ScreenCoordinate HexToScreen(HexCoordinate coords, int scale, Coordinate location)
        {
            return WorldToScreen(HexToWorld(coords, scale), location);
        }

        #endregion

        #region ScreenToHex

        public HexCoordinate ScreenToHex(ScreenCoordinate coords, int scale, Coordinate location)
        {
            return WorldToHex(ScreenToWorld(coords, location), scale);
        }

        #endregion

        #region GetHexagon

        public Hexagon GetHexagon(Coordinate xy, int scale)
        {
            var cpl = Math.Cos(Math.PI / 6) * scale;
            var spl = 0.5d * scale;

            var points = new Point[6];

            points[0] = xy.Point();
            points[1] = new Point((int)Math.Round(xy.X - cpl), (int)Math.Round(xy.Y + spl));
            points[2] = new Point((int)Math.Round(xy.X - cpl), (int)Math.Round(xy.Y + spl + scale));
            points[3] = new Point(xy.X, xy.Y + 2 * scale);
            points[4] = new Point((int)Math.Round(xy.X + cpl), (int)Math.Round(xy.Y + spl + scale));
            points[5] = new Point((int)Math.Round(xy.X + cpl), (int)Math.Round(xy.Y + spl));

            return new Hexagon(points);
        }

        #endregion

        public List<HexCoordinate> Get2DRange(HexCoordinate start, HexCoordinate end)
        {
            var rangeX = Enumerable.Range(start.X, end.X - start.X + 1);
            var rangeY = Enumerable.Range(start.Y, end.Y - start.Y + 1);

            var list = new List<HexCoordinate>();

            foreach (var x in rangeX)
            {
                foreach (var y in rangeY)
                {
                    list.Add(XY.Hex(x, y));
                }
            }

            return list;
        }
    }
}
