using TBSG.Data.Abilities;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;

namespace TBSG.Data
{
    public class Command
    {
        public Entity Commandee { get; }
        public Entity TargetEntity { get; }
        public Tile TargetTile { get; }
        public Ability Ability { get; }

        public Command(
            Entity commandee,
            Entity targetEntity,
            Tile targetTile,
            Ability ability)
        {
            Commandee = commandee;
            TargetEntity = targetEntity;
            TargetTile = targetTile;
            Ability = ability;
        }
    }
}
