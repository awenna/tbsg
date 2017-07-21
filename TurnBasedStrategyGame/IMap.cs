using TBSG.Data;

namespace TBSG
{
    public interface IMap
    {
        ITile TileAt(HexCoordinate location);
        bool LocationIsWithinBounds(HexCoordinate location);
    }
}
