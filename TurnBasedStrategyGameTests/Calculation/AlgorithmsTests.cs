using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TBSG.Data;
using Rhino.Mocks;

namespace TBSG.Calculation
{
    public class AlgorithmsTests
    {
        private readonly Algorithms Target;

        public AlgorithmsTests()
        {
            Target = new Algorithms();
        }

        [Fact]
        public void Get2DRange_StartAndEndEqual_ReturnOneEntry()
        {
            var expected = new List<HexCoordinate>
            {
                XY.Hex(0, 1)
            };

            var result = Target.Get2DRange(XY.Hex(0, 1), XY.Hex(0, 1));

            Assert.True(result.SequenceEqual(expected));
        }

        [Fact]
        public void Get2DRange_CalculatesSimpleRange()
        {
            var expected = new List<HexCoordinate>
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
            var expected = new List<HexCoordinate>
            {
                XY.Hex(2, 1), XY.Hex(3, 1), XY.Hex(4, 1),
                XY.Hex(2, 2), XY.Hex(3, 2), XY.Hex(4, 2),
                XY.Hex(2, 3), XY.Hex(3, 3), XY.Hex(4, 3),
                XY.Hex(2, 4), XY.Hex(3, 4), XY.Hex(4, 4),
            }.OrderBy(h => h.x);

            var result = Target.Get2DRange(XY.Hex(2, 1), XY.Hex(4, 4))
                .OrderBy(h => h.x);

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
    }
}
