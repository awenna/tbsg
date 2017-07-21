using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Data;

namespace TBSG
{
    public class Map : IMap
    {
        private readonly IMapGenerator mMapGenerator;

        private ITile[][] mMapArray;
        private HexCoordinate mapSize;

        public Coordinate Dimensions { get; set; }

        public Map(IMapGenerator mapGenerator, Coordinate dimensions)
        {
            mMapGenerator = mapGenerator;
            Dimensions = dimensions;
            mapSize = new HexCoordinate(dimensions.x - 1, dimensions.y - 1);

            mMapArray = mMapGenerator.GenerateMap(dimensions);
        }

        public ITile TileAt(HexCoordinate location)
        {
            if (LocationIsWithinBounds(location))
            {
                return mMapArray[location.x][location.y];
            }
            return null;
        }

        public bool LocationIsWithinBounds(HexCoordinate location)
        {
            if (location.x < 0 ||
                location.y < 0 ||
                location.x > mapSize.x ||
                location.y > mapSize.y)
            {
                return false;
            }
            return true;
        }
    }
}
