using TBSG.Data.Hexmap;

namespace TBSG.Model.Hexmap
{
    public interface IMapGenerator
    {
        Tile[][] GenerateMap(Coordinate dimensions);
    }
}
