using System;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Data.View;

namespace TBSG.Model.Hexmap
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
            mapSize = new HexCoordinate(dimensions.X - 1, dimensions.Y - 1);

            mTileOccupants = new TileOccupants();
            mMapArray = mMapGenerator.GenerateMap(dimensions);
        }

        public void MoveEntityTo(Entity entity, Tile tile)
        {
            if (tile.IsFree())
            {
                if (mTileOccupants.Get(entity) != null)
                {
                    mTileOccupants.Get(entity).Entity = null;
                }
                mTileOccupants.Set(entity, tile);
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
                return mMapArray[location.X][location.Y];
            }
            return null;
        }

        public Entity EntityAt(HexCoordinate location)
        {
            if (LocationIsWithinBounds(location))
            {
                return mMapArray[location.X][location.Y].Entity;
            }
            return null;
        }

        public Tile TileOf(Entity entity)
        {
            return mTileOccupants.Get(entity);
        }

        public HexCoordinate LocationOf(ISelection selection)
        {
            var entity = selection.GetEntity();
            if (entity != null)
            {
                return TileOf(entity).Location;
            }
            var tile = selection.GetTile();
            if (tile != null)
            {
                return tile.Location;
            }
            throw new ArgumentException();
        }

        public bool LocationIsWithinBounds(HexCoordinate location)
        {
            if (location.X < 0 ||
                location.Y < 0 ||
                location.X > mapSize.X ||
                location.Y > mapSize.Y)
            {
                return false;
            }
            return true;
        }
    }
}
