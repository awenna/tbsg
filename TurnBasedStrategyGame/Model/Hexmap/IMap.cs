using TBSG.Data;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Data.View;

namespace TBSG.Model.Hexmap
{
    public interface IMap
    {
        Tile TileAt(HexCoord location);
        Tile TileOf(Entity entity);
        Entity EntityAt(HexCoord location);
        HexCoord LocationOf(ISelection selection);
        void MoveEntityTo(Entity entity, Tile tile);
        void MoveEntityTo(Entity entity, HexCoord targetLocation);
        bool LocationIsWithinBounds(HexCoord location);
        bool InRange(Entity entity, HexCoord targetLocation, int range, Tag.Range rangeType);
    }
}
