using System;
using Common.Graphics;
using TBSG.Data.Abilities;

namespace TBSG.Data.Entities
{
    [Serializable]
    public class Entity
    {
        public Ability DefaultAbility { get; set; }
        public Stat ActionPoints { get; set; }
        public Representation Representation { get; set; }
    }
}
