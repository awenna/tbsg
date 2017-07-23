using TBSG.Data;

namespace TBSG.Model
{
    public class Command
    {
        public Entity Commandee { get; set; }
        public Entity TargetEntity { get; set; }
        public Tile TargetTile { get; set; }
        public Ability Ability { get; set; }

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
