using TBSG.Data;

namespace TBSG.Model
{
    public class Command
    {
        public Entity Commandee { get; set; }
        public Entity TargetEntity { get; set; }
        public Tile TargetTile { get; set; }
        public Ability Ability { get; set; }
    }
}
