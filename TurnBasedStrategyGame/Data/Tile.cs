using TBSG.Model;

namespace TBSG.Data
{
    public class Tile
    {
        public TerrainType TerrainType { get; set; }
        public Entity Entity { get; set; }

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
