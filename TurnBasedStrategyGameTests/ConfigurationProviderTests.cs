using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Rhino.Mocks;

namespace TBSG
{
    public class ConfigurationProviderTests
    {
        [Fact]
        public void GetValue_ReturnsCorrectValue()
        {
            var provider = new ConfigurationProvider();

            var result = provider.GetValue<string>("TestKey");

            Assert.Equal("True", result);
        }
    }
}
