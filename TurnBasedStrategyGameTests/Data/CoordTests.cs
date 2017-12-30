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

        #endregion

        #region Derivatives

        #endregion
    }
}
