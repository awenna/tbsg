using TBSG.Data.Entities;
using TBSG.Data.Hexmap;

namespace TBSG.Data.View
{
    public class Selection : ISelection
    {
        public Entity Entity { get; set; }
        public Tile Tile { get; set; }

        public Entity GetEntity()
        {
            return Entity;
        }

        public Tile GetTile()
        {
            return Tile;
        }

        public void Set(Tile tile)
        {
            if (tile == null)
            {
                Tile = null;
                Entity = null;
                return;
            }
            if (tile.Occupant.HasNoMelee())
            {
                if (!tile.Occupant.IsEmpty())
                Entity = tile.Occupant.GetSingleEntity();
                Tile = null;
                return;
            }
            Entity = null;
            Tile = tile;
        }

        public void Set(Entity entity)
        {
            Entity = entity;
            Tile = null;
        }

        public bool Exists()
        {
            return Entity != null || Tile != null;
        }

        public void Clear()
        {
            Entity = null;
            Tile = null;
        }
    }
}
