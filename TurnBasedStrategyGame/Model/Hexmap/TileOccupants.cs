using System.Collections.Generic;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;

namespace TBSG.Model.Hexmap
{
    public class TileOccupants
    {
        protected Dictionary<Entity, Tile> Occupants;

        public TileOccupants()
        {
            Occupants = new Dictionary<Entity, Tile>();
        }

        public Tile Get(Entity entity)
        {
            if (Occupants.ContainsKey(entity))
            {
                return Occupants[entity];
            }
            return null;
        }

        public void Set(Entity entity, Tile tile)
        {
            if (Occupants.ContainsKey(entity))
            {
                Occupants[entity] = tile;
                return;
            }
            Occupants.Add(entity, tile);
        }
    }
}
