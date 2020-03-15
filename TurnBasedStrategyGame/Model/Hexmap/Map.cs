using System;
using TBSG.Data;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Data.View;

namespace TBSG.Model.Hexmap
{
    public class Map : IMap
    {
        private readonly IMapFunctions mMapFunctions;

        private readonly TileArray mTileArray;
        private readonly TileOccupants mTileOccupants;
        private readonly HexCoord mapSize;

        public Map(
            TileArray tileArray,
            TileOccupants tileOccupants,
            IMapFunctions mapFunctions)
        {
            mTileOccupants = tileOccupants;
            mTileArray = tileArray;
            mMapFunctions = mapFunctions;

            var size = tileArray.Size();
            mapSize = XY.Hex(size.X, size.Y) - XY.Hex(1, 1);
        }

        public void MoveEntityTo(Entity entity, Tile tile)
        {
            if (tile.IsFree())
            {
                if (mTileOccupants.Get(entity) != null)
                {
                    mTileOccupants.Get(entity).Occupant.IsEmpty();
                }
                mTileOccupants.Set(entity, tile);
                tile.Occupant = new TileOccupant(entity);
            }
        }

        public void MoveEntityTo(Entity entity, HexCoord targetLocation)
        {
            CheckWithinBounds(targetLocation);

            var tile = TileAt(targetLocation);

            MoveEntityTo(entity, tile);
        }

        public Tile TileAt(HexCoord location)
        {
            if (LocationIsWithinBounds(location))
            {
                return mTileArray.GetTile(location.X,location.Y);
            }
            return null;
        }

        public Entity EntityAt(HexCoord location)
        {
            if (LocationIsWithinBounds(location))
            {
                var tile = mTileArray.GetTile(location.X, location.Y);
                if (tile.Occupant.HasNoMelee())
                    return tile.Occupant.GetSingleEntity();
                throw new NotImplementedException();
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
            throw new ArgumentException("Selection is empty.");
        }

        public bool LocationIsWithinBounds(HexCoord location)
        {
            if (location.X >= 0 &&
                location.Y >= 0 &&
                location.X <= mapSize.X &&
                location.Y <= mapSize.Y)
                    return true;
            return false;
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

        private void CheckWithinBounds(HexCoord coordinate)
        {
            if (!LocationIsWithinBounds(coordinate))
                throw new ArgumentException("Location outside map bounds.");
        }
    }
}
