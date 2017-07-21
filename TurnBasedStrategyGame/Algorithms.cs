﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TBSG.Data;

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

            if (coords.y % 2 == 0)
            {
                x = (int)(cpl * (2 * coords.x + 1));
                y = (int)(3 * coords.y * scale / 2);
            }
            else
            {
                x = (int)(2 * cpl * (coords.x + 1));
                y = (int)(spl + scale + 3 * (coords.y - 1) * scale / 2);
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

            int row = (int)(coords.y / gridHeight);
            int column;
            if (row % 2 == 0)
                column = (int)(coords.x / gridWidth);
            else
                column = (int)((coords.x - gridWidth / 2) / gridWidth);

            double relY = coords.y - row * gridHeight;
            double relX;
            if (row % 2 == 0)
                relX = coords.x - column * gridWidth;
            else
                relX = coords.x - (column * gridWidth) - gridWidth / 2;

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
                if (row % 2 == 0) column--;
            }
            
            return new HexCoordinate(column, row);
        }

        #endregion

        #region WorldToScreen

        public ScreenCoordinate WorldToScreen(WorldCoordinate coords, Coordinate location)
        {
            return new ScreenCoordinate(coords.x - location.x, coords.y - location.y);
        }

        #endregion

        #region ScreenToWorld

        public WorldCoordinate ScreenToWorld(ScreenCoordinate coords, Coordinate location)
        {
            return new WorldCoordinate(coords.x + location.x, coords.y + location.y);
        }

        #endregion

        public Hexagon GetHexagon(Coordinate xy, int scale)
        {
            var cpl = Math.Cos(Math.PI / 6) * scale;
            var spl = 0.5d * scale;

            var points = new Point[6];

            points[0] = xy.Point();
            points[1] = new Point((int)Math.Round(xy.x - cpl), (int)Math.Round(xy.y + spl));
            points[2] = new Point((int)Math.Round(xy.x - cpl), (int)Math.Round(xy.y + spl + scale));
            points[3] = new Point(xy.x, xy.y + 2 * scale);
            points[4] = new Point((int)Math.Round(xy.x + cpl), (int)Math.Round(xy.y + spl + scale));
            points[5] = new Point((int)Math.Round(xy.x + cpl), (int)Math.Round(xy.y + spl));

            return new Hexagon(points);
        }
    }
}
