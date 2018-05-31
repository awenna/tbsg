using TBSG.Data.Entities;

namespace TBSG.Data.Hexmap
{
    public class Tile
    {
        public TerrainType TerrainType { get; set; }
        public Entity Entity { get; set; }
        public HexCoord Location { get; set; }

        public Tile() { }

        public Tile(TerrainType terrainType)
        {
            TerrainType = terrainType;
        }

        public bool IsFree()
        {
            if (Entity == null)
            {
                return true;
            }
            return false;
        }
    }
}
