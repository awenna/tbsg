using System;
using TBSG.Data.Hexmap;
using Xunit;

namespace TBSG.Data
{
    public class CoordinateTests
    {
        [Fact]
        public void Constructor_Coords_HoldsConstructorValues()
        {
            var coord = new Coordinate(3, 5);

            Assert.Equal(coord.X, 3);
            Assert.Equal(coord.Y, 5);
        }

        #region Operators

        [Fact]
        public void Coords_SupportsAddition()
        {
            var first = new Coordinate(1, 2);
            var second = new Coordinate(2, 5);

            var result = first + second;

            var expected = new Coordinate(3, 7);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Coords_SupportsSubstraction()
        {
            var first = new Coordinate(1, 2);
            var second = new Coordinate(2, 5);

            var result = first - second;

            var expected = new Coordinate(-1, -3);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Coords_SupportsMultiplication()
        {
            var first = new Coordinate(1, 2);
            var second = new Coordinate(2, 5);

            var result = first * second;

            var expected = new Coordinate(2, 10);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Coords_SimpleDivision_SupportsDivision()
        {
            var first = new Coordinate(10, 20);
            var second = new Coordinate(2, 5);

            var result = first / second;

            var expected = new Coordinate(5, 4);

            Assert.Equal(result, expected);
        }

        [Fact]
        public void Coords_HasRemainer_SupportsDivision()
        {
            var first = new Coordinate(1, 22);
            var second = new Coordinate(3, 5);

            var result = first / second;

            var expected = new Coordinate(0, 4);

            Assert.Equal(result, expected);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(4, 1, 4, 1)]
        [InlineData(4, -2, 3, -2)]
        [InlineData(-2, 5, 0, 5)]
        [InlineData(-1, -1, -2, -1)]
        [InlineData(1, 3, 2, 3)]
        public void AxialCoord_CorrectlyConvertsToHex(int x1, int y1, int x2, int y2)
        {
            var cube = XY.Cube(x1, y1);
            var expected = XY.Hex(x2, y2);
            var result = cube.ToHexCoordinate();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(2, 2, 1, 2)]
        [InlineData(-1, -1, 0, -1)]
        [InlineData(0, 4, -2, 4)]
        [InlineData(5, 0, 5, 0)]
        [InlineData(3, 4, 1, 4)]
        public void HexCoord_CorrectlyConvertsToAxial(int x1, int y1, int x2, int y2)
        {
            var hex = XY.Hex(x1, y1);
            var expected = XY.Cube(x2, y2);
            var result = hex.ToCubeCoord();

            Assert.Equal(expected, result);
        }

        #endregion

        #region Derivatives

        #endregion
    }
}
