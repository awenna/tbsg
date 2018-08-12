using TBSG.Data.Hexmap;

namespace TBSG.Model.Hexmap
{
    public interface IMapGenerator
    {
        TileArray GenerateMap(Coordinate dimensions);
    }
}
