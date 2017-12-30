using System.Collections.Generic;

namespace TBSG.Data.Abilities
{
    public class Effect
    {
        public Tag.Effects Tag { get; set; }
        public object Value { get; set; }
        public IEnumerable<Effect> Children { get; set; }
    }
}
