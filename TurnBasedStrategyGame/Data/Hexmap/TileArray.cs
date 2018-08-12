using System;
using System.Linq;

namespace TBSG.Data.Hexmap
{
    [Serializable]
    public class TileArray
    {
        private static Tile[][] Tiles;

        public TileArray(Tile[][] tiles)
        {
            Tiles = tiles;
        }

        public Tile[][] GetTiles()
        {
            return Tiles;
        }

        public Tile GetTile(int x, int y)
        {
            return Tiles[x][y];
        }

        public Coordinate Size()
        {
            return new Coordinate(Tiles.First().Length, Tiles.Length);
        }
    }
}
