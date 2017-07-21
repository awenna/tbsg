using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Rhino.Mocks;
using TBSG.Data;

namespace TBSG
{
    public class MapGeneratorTests
    {
        [Fact]
        public void MapGenerator_GeneratesMapOfGivenSize()
        {
            var generator = new MapGenerator();

            var result = generator.GenerateMap(new Coordinate(3, 7));

            Assert.Equal(3, result.Count());
            Assert.Equal(7, result.First().Count());
        }

        [Fact]
        public void MapGenerator_NoNullsAfterGeneration()
        {
            var generator = new MapGenerator();

            var result = generator.GenerateMap(new Coordinate(2, 3));

            Assert.True(result.All(_ => _.All(u => u != null)));
        }
    }
}
