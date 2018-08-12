using System;
using System.Collections.Generic;

namespace TBSG.Data.Abilities
{
    [Serializable]
    public class Ability
    {
        public Tag.TargetMode TargetMode { get; }
        public IEnumerable<TargettedEffect> Effects { get; }
        public IEnumerable<Limitation> Limitations { get; }

        public Ability(
            Tag.TargetMode targetMode,
            IEnumerable<TargettedEffect> effects,
            IEnumerable<Limitation> limitations)
        {
            TargetMode = targetMode;
            Effects = effects;
            Limitations = limitations;
        }
    }

    [Serializable]
    public class Limitation
    {
        public Tag.Limitation Tag { get; }
        public int Value { get; }

        public Limitation(Tag.Limitation tag, int value)
        {
            Tag = tag;
            Value = value;
        }
    }

    [Serializable]
    public class TargettedEffect
    {
        public Tag.Target Target { get; }
        public Effect Effect { get; }

        public TargettedEffect(Tag.Target target, Effect effect)
        {
            Target = target;
            Effect = effect;
        }
    }
}
