using TBSG.Data.Abilities;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Model.Hexmap;

namespace TBSG.Model
{
    public interface IEffectApplier
    {
        void Apply(IMap map, Effect effect, Entity entity);
        void Apply(IMap map, Effect effect, Tile tile);
        void Apply(IMap map, Effect effect, Entity entity, Tile tile);
    }
}
