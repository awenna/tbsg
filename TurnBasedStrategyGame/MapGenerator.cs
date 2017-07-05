using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedStrategyGame
{
    public class MapGenerator : IMapGenerator
    {
        public ITile[][] GenerateMap(Coords dimensions)
        {
            ITile[][] tileArray = new Tile[dimensions.x][];
            for (int x = 0; x < dimensions.x; x++)
            {
                for (int y = 0; y < dimensions.y; y++)
                {

                }
            }
            return tileArray;
        }
    }
}
