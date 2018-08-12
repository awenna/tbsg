using System;
using System.Reflection;
using TBSG.Data;
using TBSG.Model.Hexmap;

namespace TBSG.Model
{
    public class CommandResolver : ICommandResolver
    {
        private readonly IEffectApplier mEffectApplier;
        private readonly IEntityHandler mEntityHandler;

        public CommandResolver(
            IEffectApplier effectApplier, IEntityHandler entityHandler)
        {
            mEffectApplier = effectApplier;
            mEntityHandler = entityHandler;
        }

        public bool IsValid(Command command, IMap map)
        {
            var ability = command.Ability;
            foreach (var limitation in ability.Limitations)
            {
                switch (limitation.Tag)
                {
                    case Tag.Limitation.Range:
                        var inRange = map.InRange(
                            command.Commandee,
                            command.TargetTile.Location,
                            limitation.Value,
                            Tag.Range.Absolute);
                        if (!inRange)
                        {
                            return false;
                        }
                        break;
                }
            }
            return true;
        }

        public IMap Resolve(Command command, IMap map)
        {
            var targettedEffects = command.Ability.Effects;

            foreach(var targettedEffect in targettedEffects)
            {
                switch (targettedEffect.Target)
                {
                    case Tag.Target.Self:
                        mEffectApplier.Apply(map, targettedEffect.Effect, command.Commandee);
                        break;
                    case Tag.Target.Another:
                        mEffectApplier.Apply(map, targettedEffect.Effect, command.TargetEntity);
                        break;
                    case Tag.Target.Ground:
                        mEffectApplier.Apply(map, targettedEffect.Effect, command.TargetTile);
                        break;
                    case Tag.Target.SelfAndGround:
                        mEffectApplier.Apply(map, targettedEffect.Effect, command.Commandee, command.TargetTile);
                        break;
                }
            }

            return map;
        }
    }
}
