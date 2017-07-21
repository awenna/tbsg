using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedStrategyGame.Data;

namespace TurnBasedStrategyGame
{
    public interface IAlgorithms
    {
        WorldCoordinate HexToWorld(HexCoordinate coords, int scale);
        HexCoordinate WorldToHex(WorldCoordinate coords, int scale);

        ScreenCoordinate WorldToScreen(WorldCoordinate coords, Coordinate location);
        WorldCoordinate ScreenToWorld(ScreenCoordinate coords, Coordinate location);

        Hexagon GetHexagon(Coordinate xy, int scale);
    }
}
