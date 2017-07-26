using TBSG.Data;

namespace TBSG.Model
{
    public interface IEffectApplier
    {
        void Apply(Effect effect, Entity entity);
        void Apply(Effect effect, Tile tile);
        void Apply(Effect effect, Entity entity, Tile tile);
    }
}
