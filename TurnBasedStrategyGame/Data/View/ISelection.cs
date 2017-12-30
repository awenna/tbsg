using TBSG.Data.Entities;
using TBSG.Data.Hexmap;

namespace TBSG.Data.View
{
    public interface ISelection
    {
        Entity GetEntity();
        Tile GetTile();
        void Set(Tile tile);
        void Set(Entity entity);
        bool Exists();
        void Clear();
    }
}
