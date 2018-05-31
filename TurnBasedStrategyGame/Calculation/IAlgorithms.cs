using System.Collections.Generic;
using TBSG.Data.Hexmap;

namespace TBSG
{
    public interface IAlgorithms
    {
        WorldCoord HexToWorld(HexCoord coords, int scale);
        HexCoord WorldToHex(WorldCoord coords, int scale);

        ScreenCoord WorldToScreen(WorldCoord coords, Coordinate location);
        WorldCoord ScreenToWorld(ScreenCoord coords, Coordinate location);

        ScreenCoord HexToScreen(HexCoord coords, int scale, Coordinate location);
        HexCoord ScreenToHex(ScreenCoord coords, int scale, Coordinate location);

        Hexagon GetHexagon(Coordinate xy, int scale);

        List<HexCoord> Get2DRange(HexCoord start, HexCoord end);

        double HexDistance(HexCoord first, HexCoord second);
    }
}
