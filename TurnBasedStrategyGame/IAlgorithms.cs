using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedStrategyGame
{
    public interface IAlgorithms
    {
        WorldCoordinate GetGridToWorldCoordinate(HexCoordinate coords, int scale);
        HexCoordinate GetWorldToGridCoordinate(WorldCoordinate coords, int scale);

        ScreenCoordinate GetWorldToScreenCoordinate(WorldCoordinate coords, Coordinate location);
        WorldCoordinate GetScreenToWorldCoordinate(ScreenCoordinate coords, Coordinate location);

        Hexagon GetHexagon(Coordinate xy, int scale);
    }
}
