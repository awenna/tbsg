using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Data;

namespace TBSG.Model
{
    public class Map : IMap
    {
        private readonly IMapGenerator mMapGenerator;

        private Tile[][] mMapArray;
        private TileOccupants mTileOccupants;
        private HexCoordinate mapSize;

        public Coordinate Dimensions { get; set; }

        public Map(IMapGenerator mapGenerator, Coordinate dimensions)
        {
            mMapGenerator = mapGenerator;
            Dimensions = dimensions;
            mapSize = new HexCoordinate(dimensions.x - 1, dimensions.y - 1);

            mTileOccupants = new TileOccupants();
            mMapArray = mMapGenerator.GenerateMap(dimensions);
        }

        public void MoveEntityTo(Entity entity, Tile tile)
        {
            if (tile.IsFree())
            {
                if (mTileOccupants.Get(entity) != null)
                {
                    mTileOccupants.Set(entity, tile);
                }
                tile.Entity = entity;
            }
        }

        public void MoveEntityTo(Entity entity, HexCoordinate targetLocation)
        {
            var tile = TileAt(targetLocation);

            MoveEntityTo(entity, tile);
        }

        public Tile TileAt(HexCoordinate location)
        {
            if (LocationIsWithinBounds(location))
            {
                return mMapArray[location.x][location.y];
            }
            return null;
        }

        public Entity EntityAt(HexCoordinate location)
        {
            if (LocationIsWithinBounds(location))
            {
                return mMapArray[location.x][location.y].Entity;
            }
            return null;
        }

        public Tile TileOf(Entity entity)
        {
            return mTileOccupants.Get(entity);
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
