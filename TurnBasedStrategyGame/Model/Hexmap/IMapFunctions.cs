using TBSG.Data;
using TBSG.Data.Hexmap;

namespace TBSG.Model.Hexmap
{
    public interface IMapFunctions
    {
        double Distance
            (HexCoord startLocation, HexCoord targetLocation, Tag.Range rangeType);
    }
}
