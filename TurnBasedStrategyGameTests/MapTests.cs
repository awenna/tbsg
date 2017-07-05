using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace TurnBasedStrategyGame
{
    [TestClass]
    public class MapTests
    {
        private readonly IMapGenerator mMapGenerator;
        private readonly IConfigurationProvider mConfigurationProvider;
        public MapTests()
        {
            mMapGenerator = MockRepository.GenerateStub<IMapGenerator>();
            mConfigurationProvider = new TestConfigurationProvider();
        }

        [TestMethod]
        public void Constructor_SetsMapSizeToParameter()
        {
            var map = new Map(mMapGenerator, new Coords(3, 5));

            Assert.AreEqual(map.Dimensions, new Coords(3, 5));
        }

        [TestMethod]
        public void TileAt_ReturnsValue()
        {
            var dimensions = new Coords(1, 1);
            var tileArray = new[] { new[] { new Tile() } };

            mMapGenerator.Stub(_ => _.GenerateMap(Arg<Coords>.Is.Anything))
                .Return(tileArray);

            var map = new Map(mMapGenerator, dimensions);

            var tile = map.TileAt(new Coords(0, 0));

            Assert.IsNotNull(tile);
        }

        [TestMethod]
        public void TileAt_SizeOneXOne_ReturnsCorrectTile()
        {
            var tile = new Tile();
            var tileArray = new[] { new[] { tile } };
            var dimensions = new Coords(1, 1);

            mMapGenerator.Stub(_ => _.GenerateMap(Arg<Coords>.Is.Anything))
                .Return(tileArray);

            var map = new Map(mMapGenerator, dimensions);

            var result = map.TileAt(new Coords(0, 0));
            Assert.AreEqual(tile, result);
        }

        [TestMethod]
        public void TileAt_OutsideBounds_ReturnsNull()
        {
            var tileArray = new[] { new[] { new Tile() } };

            mMapGenerator.Stub(_ => _.GenerateMap(Arg<Coords>.Is.Anything))
                .Return(tileArray);

            var map = new Map(mMapGenerator, new Coords(1, 1));

            var resultLeft = map.TileAt(new Coords(-1, 0));
            var resultRight = map.TileAt(new Coords(0, 2));
            var resultUp = map.TileAt(new Coords(0, -1));
            var resultDown = map.TileAt(new Coords(0, 2));

            Assert.IsNull(resultLeft);
            Assert.IsNull(resultRight);
            Assert.IsNull(resultUp);
            Assert.IsNull(resultDown);
        }
    }
}
