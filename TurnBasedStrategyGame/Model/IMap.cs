using TBSG.Data;

namespace TBSG.Model
{
    public interface IMap
    {
        Tile TileAt(HexCoordinate location);
        bool LocationIsWithinBounds(HexCoordinate location);
    }
}
