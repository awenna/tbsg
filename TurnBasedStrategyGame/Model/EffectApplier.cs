using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Data;

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
