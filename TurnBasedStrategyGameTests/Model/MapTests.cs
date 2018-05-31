using Xunit;
using Rhino.Mocks;
using TBSG.Data;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Model.Hexmap;

namespace TBSG.Model
{
    public class MapTests
    {
        #region Fields

        private readonly IMapGenerator mMapGenerator;
        private readonly IAlgorithms mAlgorithms;
        private readonly IMapFunctions mMapFunctions;

        private readonly Map target;

        #endregion

        #region Constructor

        public MapTests()
        {
            mMapGenerator = MockRepository.GenerateStub<IMapGenerator>();
            mAlgorithms = MockRepository.GenerateStub<IAlgorithms>();
            mMapFunctions = MockRepository.GenerateStub<IMapFunctions>();

            target = SetupTestMap();
        }

        #endregion

        #region MapConstructor

        [Fact]
        public void Constructor_SetsMapSizeToParameter()
        {
            var map = new Map(mMapGenerator, new Coordinate(3, 5), mMapFunctions);

            Assert.Equal(map.Dimensions, new Coordinate(3, 5));
        }

        #endregion

        #region TileAt

        [Fact]
        public void TileAt_ReturnsValue()
        {
            var dimensions = new Coordinate(1, 1);
            var tileArray = new[] { new[] { new Tile() } };

            mMapGenerator.Stub(_ => _.GenerateMap(Arg<Coordinate>.Is.Anything))
                .Return(tileArray);

            var map = new Map(mMapGenerator, dimensions, mMapFunctions);

            var tile = map.TileAt(new HexCoord(0, 0));

            Assert.NotNull(tile);
        }

        [Fact]
        public void TileAt_OutsideBounds_ThrowsOutOfBoundsException()
        {
            SetupOneByOneMap();

            var map = new Map(mMapGenerator, new Coordinate(1, 1), mMapFunctions);

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

        [Fact]
        public void LocationIsWithinBounds_ReturnsCorrectInEdgeCases()
        {
            SetupOneByOneMap();

            var map = new Map(mMapGenerator, new Coordinate(1, 1), mMapFunctions);

            var resultRight = map.LocationIsWithinBounds(new HexCoord(1, 0));
            var resultDown = map.LocationIsWithinBounds(new HexCoord(0, 1));

            Assert.False(resultRight);
            Assert.False(resultDown);
        }

        #endregion

        #region MoveEntityTo

        [Fact]
        public void MoveEntityTo_MovesEntity()
        {
            SetupOneByOneMap();

            var map = new Map(mMapGenerator, new Coordinate(1, 1), mMapFunctions);

            var entity = new Entity();

            map.MoveEntityTo(entity, XY.Hex(0,0));

            Assert.Equal(entity, map.EntityAt(XY.Hex(0, 0)));
        }

        [Fact]
        public void MoveEntityTo_NoSpace_DoNotMove()
        {
            SetupOneByOneMap();

            var map = new Map(mMapGenerator, new Coordinate(1, 1), mMapFunctions);

            var occupant = new Entity();
            var entity = new Entity();

            map.MoveEntityTo(occupant, XY.Hex(0, 0));
            map.MoveEntityTo(entity, XY.Hex(0, 0));

            Assert.NotEqual(entity, map.EntityAt(XY.Hex(0, 0)));
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
        /*
        [Fact]
        public void InRange_Absolute_CallsMapFunctionsCorrect()
        {
            var entity = new Entity();
            var location = XY.Hex(0, 0);

            target.MoveEntityTo(entity, XY.Hex(0,0));
            target.InRange(entity, location, 3, Tag.Range.Absolute);

            mMapFunctions
                .AssertWasCalled(_=>_.Distance(XY.Hex(0,0), location, Tag.Range.Absolute));
        }*/

        #endregion

        #region Helpers

        private void SetupOneByOneMap()
        {
            var tileArray = new[] { new[] { new Tile() } };

            mMapGenerator.Stub(_ => _.GenerateMap(Arg<Coordinate>.Is.Anything))
                .Return(tileArray);
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

            mMapGenerator.Stub(_ => _.GenerateMap(Arg<Coordinate>.Is.Anything))
                .Return(tileArray);

            return new Map(mMapGenerator, new Coordinate(4, 4), mMapFunctions);
        }

        #endregion
    }
}
