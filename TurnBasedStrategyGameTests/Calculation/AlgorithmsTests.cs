using System;
using System.Collections.Generic;
using System.Linq;
using TBSG.Data.Hexmap;
using Xunit;

namespace TBSG.Calculation
{
    public class AlgorithmsTests
    {
        private readonly Algorithms Target;

        public AlgorithmsTests()
        {
            Target = new Algorithms();
        }

        #region Get2DRange

        [Fact]
        public void Get2DRange_StartAndEndEqual_ReturnOneEntry()
        {
            var expected = new List<HexCoord>
            {
                XY.Hex(0, 1)
            };

            var result = Target.Get2DRange(XY.Hex(0, 1), XY.Hex(0, 1));

            Assert.True(result.SequenceEqual(expected));
        }

        [Fact]
        public void Get2DRange_CalculatesSimpleRange()
        {
            var expected = new List<HexCoord>
            {
                XY.Hex(1, 2),
                XY.Hex(1, 3)
            };

            var result = Target.Get2DRange(XY.Hex(1, 2), XY.Hex(1, 3));

            Assert.True(result.SequenceEqual(expected));
        }

        [Fact]
        public void Get2DRange_CalculatesLargeRange()
        {
            var expected = new List<HexCoord>
            {
                XY.Hex(2, 1), XY.Hex(3, 1), XY.Hex(4, 1),
                XY.Hex(2, 2), XY.Hex(3, 2), XY.Hex(4, 2),
                XY.Hex(2, 3), XY.Hex(3, 3), XY.Hex(4, 3),
                XY.Hex(2, 4), XY.Hex(3, 4), XY.Hex(4, 4),
            }.OrderBy(h => h.X);

            var result = Target.Get2DRange(XY.Hex(2, 1), XY.Hex(4, 4))
                .OrderBy(h => h.X);

            Assert.True(result.SequenceEqual(expected));
        }

        [Fact]
        public void Get2DRange_InvalidArguments_ThrowsError()
        {
            var exception = Record.Exception(
                () => Target.Get2DRange(XY.Hex(5, 4), XY.Hex(1, 3)));

            Assert.NotNull(exception);
            Assert.IsType(typeof(ArgumentOutOfRangeException), exception);
        }

        #endregion

        #region HexDistance

        [Fact]
        public void HexDistance_StraightLines_ReturnsCorrect()
        {
            var expected = new[] {0.0, 1.0, 2.0, 3.0, 4.0};
            var result = new[]{
                Target.HexDistance(XY.Hex(5, 5), XY.Hex(5, 5)),
                Target.HexDistance(XY.Hex(0, 1), XY.Hex(0, 0)),
                Target.HexDistance(XY.Hex(0, 0), XY.Hex(2, 0)),
                Target.HexDistance(XY.Hex(0, 0), XY.Hex(0, 3)),
                Target.HexDistance(XY.Hex(4, 0), XY.Hex(0, 0))
            };

            Assert.Equal(expected, result);
        }

        [Fact]
        public void HexDistance_RandomCases_ReturnsCorrect()
        {
            var expected = new[] { 7.0, 2.0, 2.0, 3.0, 4.0 };
            var result = new[]{
                Target.HexDistance(XY.Hex(0, 0), XY.Hex(4, 5)),
                Target.HexDistance(XY.Hex(3, 2), XY.Hex(4, 3)),
                Target.HexDistance(XY.Hex(3, 2), XY.Hex(2, 0)),
                Target.HexDistance(XY.Hex(0, 0), XY.Hex(0, 3)),
                Target.HexDistance(XY.Hex(4, 0), XY.Hex(0, 0))
            };

            Assert.Equal(expected, result);
        }

        #endregion
    }
}
