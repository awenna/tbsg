using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Data;

namespace TBSG
{
    public interface IAlgorithms
    {
        WorldCoordinate HexToWorld(HexCoordinate coords, int scale);
        HexCoordinate WorldToHex(WorldCoordinate coords, int scale);

        ScreenCoordinate WorldToScreen(WorldCoordinate coords, Coordinate location);
        WorldCoordinate ScreenToWorld(ScreenCoordinate coords, Coordinate location);

        ScreenCoordinate HexToScreen(HexCoordinate coords, int scale, Coordinate location);
        HexCoordinate ScreenToHex(ScreenCoordinate coords, int scale, Coordinate location);

        Hexagon GetHexagon(Coordinate xy, int scale);

        List<HexCoordinate> Get2DRange(HexCoordinate start, HexCoordinate end);
    }
}
