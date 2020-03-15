using System;
using TBSG.Data.Entities;

namespace TBSG.Data.Hexmap
{
    [Serializable]
    public class Tile
    {
        public TerrainType TerrainType { get; set; }
        public TileOccupant Occupant { get; set; }
        public HexCoord Location { get; set; }

        public Tile()
        {
            Occupant = new TileOccupant(null);
        }

        public Tile(TerrainType terrainType)
        {
            TerrainType = terrainType;
            Occupant = new TileOccupant(null);
        }

        public bool IsFree()
        {
            if (Occupant == null || Occupant.IsEmpty())
            {
                return true;
            }
            return false;
        }
    }
}
