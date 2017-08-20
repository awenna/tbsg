using TBSG.Data;

namespace TBSG.Model
{
    public interface IMap
    {
        Tile TileAt(HexCoordinate location);
        Entity EntityAt(HexCoordinate location);
        void MoveEntityTo(Entity entity, Tile tile);
        void MoveEntityTo(Entity entity, HexCoordinate targetLocation);
        bool LocationIsWithinBounds(HexCoordinate location);
    }
}
