using TBSG.Data.Abilities;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;

namespace TBSG.Model
{
    public interface IEffectApplier
    {
        void Apply(Effect effect, Entity entity);
        void Apply(Effect effect, Tile tile);
        void Apply(Effect effect, Entity entity, Tile tile);
    }
}
