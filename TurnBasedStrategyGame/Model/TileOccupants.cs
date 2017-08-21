using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Data;

namespace TBSG.Model
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
