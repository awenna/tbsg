using System;
using Xunit;
using Rhino.Mocks;
using Shouldly;
using TBSG.Data;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Model.Hexmap;

namespace TBSG.Model
{
    public class MapTests
    {
        #region Fields

        private readonly IAlgorithms mAlgorithms;
        private readonly IMapFunctions mMapFunctions;

        private readonly Map target;

        #endregion

        #region Constructor

        public MapTests()
        {
            mAlgorithms = MockRepository.GenerateStub<IAlgorithms>();
            mMapFunctions = MockRepository.GenerateStub<IMapFunctions>();

            target = SetupTestMap();
        }

        #endregion

        #region TileArray

        [Fact]
        public void TileArray_GivesCorrectSize()
        {
            var array = new[] {
                new[] {new Tile()},
                new[] {new Tile()},
                new[] {new Tile()}
            };
            var tileArray = new TileArray(array);
            tileArray.Size().ShouldBe(new Coordinate(3, 1));
        }

        #endregion

        #region TileAt

        [Fact]
        public void TileAt_ReturnsValue()
        {
            var tileArray = new TileArray(new[] { new[] { new Tile() } });

            var map = new Map(tileArray, new TileOccupants(), mMapFunctions);

            var tile = map.TileAt(new HexCoord(0, 0));

            Assert.NotNull(tile);
        }

        [Fact]
        public void TileAt_OutsideBounds_ThrowsOutOfBoundsException()
        {
            var map = new Map(GenerateTileArray(), new TileOccupants(), mMapFunctions);

            var resultLeft = map.TileAt(new HexCoord(-1, 0));
            var resultRight = map.TileAt(new HexCoord(0, 2));
            var resultUp = map.TileAt(new HexCoord(0, -1));
            var resultDown = map.TileAt(new HexCoord(0, 2));

            Assert.Null(resultLeft);
            Assert.Null(resultRight);
            Assert.Null(resultUp);
            Assert.Null(resultDown);
        }

        #endregion

        #region LocationIsWithinBounds

        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(2, 1, true)]
        [InlineData(-1, 0, false)]
        [InlineData(3, -1, false)]
        [InlineData(5, 3, false)]
        [InlineData(3, 3, true)]
        [InlineData(3, 2, true)]
        [InlineData(4, 4, false)]
        public void LocationIsWithinBounds_ReturnsCorrectInEdgeCases(
            int x, int y, bool withinBounds)
        {
            var map = SetupTestMap();

            var result = map.LocationIsWithinBounds(XY.Hex(x, y));
            
            result.ShouldBe(withinBounds);
        }

        #endregion

        #region MoveEntityTo

        [Fact]
        public void MoveEntityTo_MovesEntity()
        {
            var map = new Map(GenerateTileArray(), new TileOccupants(), mMapFunctions);

            var entity = new Entity();

            map.MoveEntityTo(entity, XY.Hex(0,0));

            Assert.Equal(entity, map.EntityAt(XY.Hex(0, 0)));
        }

        [Fact]
        public void MoveEntityTo_NoSpace_DoNotMove()
        {
            var map = new Map(GenerateTileArray(), new TileOccupants(), mMapFunctions);

            var occupant = new Entity();
            var entity = new Entity();

            map.MoveEntityTo(occupant, XY.Hex(0, 0));
            map.MoveEntityTo(entity, XY.Hex(0, 0));

            Assert.NotEqual(entity, map.EntityAt(XY.Hex(0, 0)));
        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(5, 5)]
        [InlineData(-3, 1)]
        public void MoveEntityTo_OutOfBounds_RaiseException(
            int x, int y)
        {
            var map = GenerateMap(GenerateTileArray());

            Assert.Throws<ArgumentException>(
                () => map.MoveEntityTo(new Entity(), XY.Hex(x, y)));
        }

        #endregion

        #region InRange

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(5, 0)]
        [InlineData(0, 5)]
        [InlineData(-2, -1)]
        [InlineData(7, 5)]
        [InlineData(7, -1)]
        [InlineData(-1, 5)]
        public void InRange_LocationOutSideBounds_ReturnFalse(int x, int y)
        {
            var entity = new Entity();
            var location = XY.Hex(x, y);

            var result = target.InRange(entity, location, 2, Tag.Range.Absolute);

            Assert.False(result);
        }

        #endregion

        #region Helpers

        private Map GenerateMap(TileArray array)
        {
            return new Map(array, new TileOccupants(), mMapFunctions);
        }

        private TileArray GenerateTileArray()
        {
            var tileArray = new[] { new[] { new Tile() } };

            return new TileArray(tileArray);
        }

        private Map SetupTestMap()
        {
            var tileArray = new[] {
                new[] {
                    new Tile(),
                    new Tile(),
                    new Tile(),
                    new Tile(),
                },
                new[] {
                    new Tile(),
                    new Tile(),
                    new Tile(),
                    new Tile(),
                },
                new[] {
                    new Tile(),
                    new Tile(),
                    new Tile(),
                    new Tile(),
                },
                new[] {
                    new Tile(),
                    new Tile(),
                    new Tile(),
                    new Tile(),
                }
            };

            return GenerateMap(new TileArray(tileArray));
        }

        #endregion
    }
}
