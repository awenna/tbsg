using TBSG.Data;
using TBSG.Model.Hexmap;

namespace TBSG.Model
{
    public class CommandResolver : ICommandResolver
    {
        private readonly IEffectApplier mEffectApplier;

        public CommandResolver(IMap map, IEffectApplier effectApplier)
        {
            mEffectApplier = effectApplier;
        }

        public void Resolve(Command command)
        {
            var targettedEffects = command.Ability.Effects;

            foreach(var targettedEffect in targettedEffects)
            {
                switch (targettedEffect.Target)
                {
                    case Tag.Target.Self:
                        mEffectApplier.Apply(targettedEffect.Effect, command.Commandee);
                        break;
                    case Tag.Target.Another:
                        mEffectApplier.Apply(targettedEffect.Effect, command.TargetEntity);
                        break;
                    case Tag.Target.Ground:
                        mEffectApplier.Apply(targettedEffect.Effect, command.TargetTile);
                        break;
                    case Tag.Target.SelfAndGround:
                        mEffectApplier.Apply(targettedEffect.Effect, command.Commandee, command.TargetTile);
                        break;
                }
            }
        }
    }
}
