using TBSG.Data;
using TBSG.View;

namespace TBSG.Model
{
    public interface IMap
    {
        Tile TileAt(HexCoordinate location);
        Tile TileOf(Entity entity);
        Entity EntityAt(HexCoordinate location);
        HexCoordinate LocationOf(ISelection selection);
        void MoveEntityTo(Entity entity, Tile tile);
        void MoveEntityTo(Entity entity, HexCoordinate targetLocation);
        bool LocationIsWithinBounds(HexCoordinate location);
    }
}
