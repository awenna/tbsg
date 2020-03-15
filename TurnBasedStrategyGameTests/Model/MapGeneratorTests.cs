using System.Linq;
using Shouldly;
using TBSG.Data.Hexmap;
using Xunit;
using TBSG.Model.Hexmap;

namespace TBSG.Model
{
    public class MapGeneratorTests
    {
        private readonly MapGenerator Target;

        public MapGeneratorTests()
        {
            Target = new MapGenerator();
        }

        [Fact]
        public void GenerateMap_GeneratesMapOfGivenSize()
        {
            var result = Target.GenerateMap(new Coordinate(3, 7));

            Assert.Equal(3, result.GetTiles().Count());
            Assert.Equal(7, result.GetTiles().First().Count());
        }

        [Fact]
        public void GenerateMap_NoNullsAfterGeneration()
        {
            var result = Target.GenerateMap(new Coordinate(2, 3));

            Assert.True(result.GetTiles().All(_ => _.All(u => u != null)));
        }

        [Fact]
        public void GenerateMap_GeneratesTerrainTypeForTiles()
        {
            var result = Target.GenerateMap(new Coordinate(1, 1));

            Assert.True(result.GetTiles().All(_ => _.All(tile => tile.TerrainType != null)));
        }

        [Fact]
        public void GenerateMap_AddsLocationToTiles()
        {
            var result = Target.GenerateMap(new Coordinate(2, 3));

            var tile = result.GetTiles()[1][2];

            tile.Location.ShouldBe(XY.Hex(1, 2));
        }
    }
}
