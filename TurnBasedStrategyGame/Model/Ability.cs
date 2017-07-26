using System;
using System.Collections.Generic;

namespace TBSG.Model
{
    public class Ability
    {
        public Tag.TargetMode TargetMode { get; set; }
        public IEnumerable<TargettedEffect> Effects { get; set; }
    }

    public class TargettedEffect
    {
        public Tag.Target Target { get; set; }
        public Effect Effect { get; set; }
    }
}
