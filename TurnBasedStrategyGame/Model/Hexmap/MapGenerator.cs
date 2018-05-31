using System;
using System.Drawing;
using TBSG.Data.Hexmap;

namespace TBSG.Model.Hexmap
{
    public class MapGenerator : IMapGenerator
    {
        public Tile[][] GenerateMap(Coordinate dimensions)
        {
            var random = new Random();
            
            Tile[][] tileArray = new Tile[dimensions.X][];
            for (int x = 0; x < dimensions.X; x++)
            {
                tileArray[x] = new Tile[dimensions.Y];
                for (int y = 0; y < dimensions.Y; y++)
                {
                    var tile = new Tile();

                    tile.Location = XY.Hex(x, y);

                    tile.TerrainType = GetTerrainType(random);

                    tileArray[x][y] = tile;
                }
            }

            return tileArray;
        }

        #region Private

        private TerrainType GetTerrainType(Random random)
        {
            var color = new Color();

            var type = random.Next(4);
            switch (type)
            {
                case 0:
                    color = Color.FromArgb(201, 189, 93);
                    break;
                case 1:
                    color = Color.FromArgb(135, 152, 87);
                    break;
                case 2:
                    color = Color.FromArgb(186, 102, 28);
                    break;
                case 3:
                    color = Color.FromArgb(161, 147, 116);
                    break;
            }

            return new TerrainType(color);
        }

        #endregion
    }
}
