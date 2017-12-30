using TBSG.Data.Abilities;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;

namespace TBSG.Data
{
    public class Command
    {
        public Entity Commandee { get; set; }
        public Entity TargetEntity { get; set; }
        public Tile TargetTile { get; set; }
        public Ability Ability { get; set; }
    }
}
