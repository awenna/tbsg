using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Data;

namespace TBSG.View
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
            if (tile.Entity != null)
            {
                Entity = tile.Entity;
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

        public HexCoordinate GetLocation()
        {
            if (Entity != null)
            {
                return Entity.Tile.Location;
            }
            if (Tile != null)
            {
                return Tile.Location;
            }
            return null;
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
