using System;
using TBSG.Data;
using TBSG.Data.Abilities;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Model.Hexmap;

namespace TBSG.Model
{
    public class EffectApplier : IEffectApplier
    {
        private readonly IMap mMap;

        public EffectApplier(IMap map)
        {
            mMap = map;
        }

        public void Apply(Effect effect, Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Apply(Effect effect, Tile tile)
        {
            throw new NotImplementedException();
        }

        public void Apply(Effect effect, Entity entity, Tile tile)
        {
            switch (effect.Tag)
            {
                case Tag.Effects.Movement:
                    mMap.MoveEntityTo(entity, tile);
                    break;
            }
            if (effect.Children != null)
            {
                foreach(var child in effect.Children)
                {
                    Apply(child, entity, tile);
                }
            }
        }
    }
}
