using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Data.View;

namespace TBSG.Model.Hexmap
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
