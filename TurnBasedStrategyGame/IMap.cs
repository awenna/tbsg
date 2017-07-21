using TBSG.Data;

namespace TBSG
{
    public interface IMap
    {
        Tile TileAt(HexCoordinate location);
        bool LocationIsWithinBounds(HexCoordinate location);
    }
}
