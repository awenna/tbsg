using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Data;

namespace TBSG
{
    public class MapGenerator : IMapGenerator
    {
        public Tile[][] GenerateMap(Coordinate dimensions)
        {
            Tile[][] tileArray = new Tile[dimensions.x][];
            for (int x = 0; x < dimensions.x; x++)
            {
                tileArray[x] = new Tile[dimensions.y];
                for (int y = 0; y < dimensions.y; y++)
                {
                    tileArray[x][y] = new Tile();
                }
            }
            return tileArray;
        }
    }
}
