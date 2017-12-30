using System.Linq;
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

            Assert.Equal(3, result.Count());
            Assert.Equal(7, result.First().Count());
        }

        [Fact]
        public void GenerateMap_NoNullsAfterGeneration()
        {
            var result = Target.GenerateMap(new Coordinate(2, 3));

            Assert.True(result.All(_ => _.All(u => u != null)));
        }

        [Fact]
        public void GenerateMap_GeneratesTerrainTypeForTiles()
        {
            var result = Target.GenerateMap(new Coordinate(1, 1));

            Assert.True(result.All(_ => _.All(tile => tile.TerrainType != null)));
        }

        [Fact]
        public void GenerateMap_AddsLocationToTiles()
        {
            var result = Target.GenerateMap(new Coordinate(2, 3));

            var tile = result[1][2];

            Assert.Equal(new Coordinate(1, 2), tile.Location);
        }
    }
}
