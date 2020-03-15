using Shouldly;
using Xunit;

namespace JsonDataTests
{
    public class SanityTest
    {
        [Fact]
        public void True_Is_True()
        {
            (true).ShouldBe(true);
        }
    }
}
