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
        public void Apply(IMap map, Effect effect, Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Apply(IMap map, Effect effect, Tile tile)
        {
            throw new NotImplementedException();
        }

        public void Apply(IMap map, Effect effect, Entity entity, Tile tile)
        {
            switch (effect.Tag)
            {
                case Tag.Effects.Movement:
                    map.MoveEntityTo(entity, tile);
                    break;
            }
            if (effect.Children != null)
            {
                foreach(var child in effect.Children)
                {
                    Apply(map, child, entity, tile);
                }
            }
        }
    }
}
