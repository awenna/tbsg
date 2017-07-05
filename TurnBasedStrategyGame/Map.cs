using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedStrategyGame
{
    public class Map : IMap
    {
        private readonly IMapGenerator mMapGenerator;

        private ITile[][] mMapArray;

        public Coords Dimensions { get; set; }

        public Map(IMapGenerator mapGenerator, Coords dimensions)
        {
            mMapGenerator = mapGenerator;
            Dimensions = dimensions;

            mMapArray = mMapGenerator.GenerateMap(dimensions);
        }

        public void GenerateMap(Coords dimensions)
        {
            Dimensions = dimensions;
        }

        public ITile TileAt(Coords location)
        {
            if (LocationIsWithinBounds(location))
            {
                return mMapArray[location.x][location.y];
            }
            return null;
        }

        public bool LocationIsWithinBounds(Coords location)
        {
            if(location.x < 0 ||
                location.y < 0 ||
                location.x > Dimensions.x ||
                location.y > Dimensions.y)
            {
                return false;
            }
            return true;
        }
    }
}
