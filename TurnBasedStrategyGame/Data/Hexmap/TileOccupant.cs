using System;
using System.Collections.Generic;
using System.Linq;
using TBSG.Data.Entities;

namespace TBSG.Data.Hexmap
{
    public class TileOccupant
    {
        private readonly Entity Entity;
        private readonly IEnumerable<Entity> Entities;

        public TileOccupant(Entity entity, IEnumerable<Entity> entities = null)
        {
            Entity = entity;
            Entities = entities;
        }

        public Entity GetSingleEntity()
        {
            if (HasNoMelee())
            {
                return Entity;
            }
            throw new InvalidOperationException("Cannot get a single Entity, multiple are present.");
        }

        public TileOccupant AddEntity(Entity entity)
        {
            if (Entity == null)
            {
                return new TileOccupant(entity);
            }
            return new TileOccupant(null, Entities.Concat(new [] { entity }));
        }

        public bool IsEmpty()
        {
            return Entity == null && Entities == null;
        }

        public bool HasNoMelee()
        {
            return Entities == null;
        }
    }
}
