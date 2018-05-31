using Rhino.Mocks;
using TBSG.Data;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Model.Hexmap;
using Xunit;

namespace TBSG.Model
{
    public class MapFunctionsTests
    {
        private readonly IAlgorithms mAlgorithms;

        private readonly MapFunctions target;

        public MapFunctionsTests()
        {
            mAlgorithms = MockRepository.GenerateStub<IAlgorithms>();
            target = new MapFunctions(mAlgorithms);
        }

        #region InRange

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(7)]
        [InlineData(9)]
        public void Distance_Absolute_SameAsAlgorithms(int expected)
        {
            var location = XY.Hex(0, 0);
            mAlgorithms.Stub(_ => _.HexDistance(location, location)).Return(expected);

            var result = target.Distance(location, location, Tag.Range.Absolute);
            Assert.Equal(expected, result);
        }

        #endregion
    }
}
