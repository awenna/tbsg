using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Rhino.Mocks;
using TBSG.Data;

namespace TBSG.Model
{
    public class MapTests
    {
        #region Fields

        private readonly IMapGenerator mMapGenerator;
        private readonly IConfigurationProvider mConfigurationProvider;

        #endregion

        #region Constructor

        public MapTests()
        {
            mMapGenerator = MockRepository.GenerateStub<IMapGenerator>();
            mConfigurationProvider = new TestConfigurationProvider();
        }

        #endregion

        #region MapConstructor

        [Fact]
        public void Constructor_SetsMapSizeToParameter()
        {
            var map = new Map(mMapGenerator, new Coordinate(3, 5));

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

            var map = new Map(mMapGenerator, dimensions);

            var tile = map.TileAt(new HexCoordinate(0, 0));

            Assert.NotNull(tile);
        }

        [Fact]
        public void TileAt_SizeOneXOne_ReturnsCorrectTile()
        {
            var tile = new Tile();
            var tileArray = new[] { new[] { tile } };
            var dimensions = new Coordinate(1, 1);

            mMapGenerator.Stub(_ => _.GenerateMap(Arg<Coordinate>.Is.Anything))
                .Return(tileArray);

            var map = new Map(mMapGenerator, dimensions);

            var result = map.TileAt(new HexCoordinate(0, 0));
            Assert.Equal(tile, result);
        }

        [Fact]
        public void TileAt_OutsideBounds_ThrowsOutOfBoundsException()
        {
            SetupOneByOneMap();

            var map = new Map(mMapGenerator, new Coordinate(1, 1));

            var resultLeft = map.TileAt(new HexCoordinate(-1, 0));
            var resultRight = map.TileAt(new HexCoordinate(0, 2));
            var resultUp = map.TileAt(new HexCoordinate(0, -1));
            var resultDown = map.TileAt(new HexCoordinate(0, 2));

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

            var map = new Map(mMapGenerator, new Coordinate(1, 1));

            var resultRight = map.LocationIsWithinBounds(new HexCoordinate(1, 0));
            var resultDown = map.LocationIsWithinBounds(new HexCoordinate(0, 1));

            Assert.False(resultRight);
            Assert.False(resultDown);
        }

        #endregion

        #region MoveEntityTo

        [Fact]
        public void MoveEntityTo_MovesEntity()
        {
            SetupOneByOneMap();

            var map = new Map(mMapGenerator, new Coordinate(1, 1));

            var entity = new Entity();

            map.MoveEntityTo(entity, XY.Hex(0,0));

            Assert.Equal(entity, map.EntityAt(XY.Hex(0, 0)));
        }

        [Fact]
        public void MoveEntityTo_NoSpace_DoNotMove()
        {
            SetupOneByOneMap();

            var map = new Map(mMapGenerator, new Coordinate(1, 1));

            var occupant = new Entity();
            var entity = new Entity();

            map.MoveEntityTo(occupant, XY.Hex(0, 0));
            map.MoveEntityTo(entity, XY.Hex(0, 0));

            Assert.NotEqual(entity, map.EntityAt(XY.Hex(0, 0)));
        }

        #endregion

        #region Helpers

        private void SetupOneByOneMap()
        {
            var tileArray = new[] { new[] { new Tile() } };

            mMapGenerator.Stub(_ => _.GenerateMap(Arg<Coordinate>.Is.Anything))
                .Return(tileArray);
        }

        #endregion
    }
}
