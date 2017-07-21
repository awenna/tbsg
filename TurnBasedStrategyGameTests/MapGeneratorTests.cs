﻿using System;
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
        public void GenerateMap_GeneratesMapOfGivenSize()
        {
            var generator = new MapGenerator();

            var result = generator.GenerateMap(new Coordinate(3, 7));

            Assert.Equal(3, result.Count());
            Assert.Equal(7, result.First().Count());
        }

        [Fact]
        public void GenerateMap_NoNullsAfterGeneration()
        {
            var generator = new MapGenerator();

            var result = generator.GenerateMap(new Coordinate(2, 3));

            Assert.True(result.All(_ => _.All(u => u != null)));
        }

        [Fact]
        public void GenerateMap_GeneratesTerrainTypeForTiles()
        {
            var generator = new MapGenerator();

            var result = generator.GenerateMap(new Coordinate(1, 1));

            Assert.True(result.All(_ => _.All(tile => tile.TerrainType != null)));
        }
    }
}
