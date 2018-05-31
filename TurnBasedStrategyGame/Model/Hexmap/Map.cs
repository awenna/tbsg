using System;
using TBSG.Data;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Data.View;

namespace TBSG.Model.Hexmap
{
    public class Map : IMap
    {
        private readonly IMapGenerator mMapGenerator;
        private readonly IMapFunctions mMapFunctions;

        private readonly Tile[][] mMapArray;
        private readonly TileOccupants mTileOccupants;
        private readonly HexCoord mapSize;

        public Coordinate Dimensions { get; set; }

        public Map(IMapGenerator mapGenerator, Coordinate dimensions, IMapFunctions mapFunctions)
        {
            mMapGenerator = mapGenerator;
            Dimensions = dimensions;
            mMapFunctions = mapFunctions;
            mapSize = new HexCoord(dimensions.X - 1, dimensions.Y - 1);

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

        public void MoveEntityTo(Entity entity, HexCoord targetLocation)
        {
            var tile = TileAt(targetLocation);

            MoveEntityTo(entity, tile);
        }

        public Tile TileAt(HexCoord location)
        {
            if (LocationIsWithinBounds(location))
            {
                return mMapArray[location.X][location.Y];
            }
            return null;
        }

        public Entity EntityAt(HexCoord location)
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

        public HexCoord LocationOf(Entity entity)
        {
            var tile = TileOf(entity);
            return tile.Location;
        }

        public HexCoord LocationOf(ISelection selection)
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

        public bool LocationIsWithinBounds(HexCoord location)
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

        public bool InRange
            (Entity entity, HexCoord targetLocation, int range, Tag.Range rangeType)
        {
            if (!LocationIsWithinBounds(targetLocation)) return false;
            var entityLocation = LocationOf(entity);

            switch (rangeType)
            {
                case Tag.Range.Absolute:
                    var distance = mMapFunctions.Distance(entityLocation, targetLocation, rangeType);
                    return distance <= range;
            }
            throw new NotImplementedException();
        }
    }
}
