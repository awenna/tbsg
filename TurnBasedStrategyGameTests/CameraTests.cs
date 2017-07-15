using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Rhino.Mocks;

namespace TurnBasedStrategyGame
{
    public class CameraTests
    {
        private readonly TestConfigurationProvider mConfigProvider;

        public CameraTests()
        {
            mConfigProvider = new TestConfigurationProvider();

            mConfigProvider.SetValue(10, "CameraScaleDefault");
        }

        [Fact]
        public void Constructor_StartsAtOrigo()
        {
            var camera = new Camera(new Algorithms(), mConfigProvider);

            var result = camera.GetLocation();

            Assert.Equal(new WorldCoordinate(0, 0), result);
        }

        [Fact]
        public void MoveBy_ChangesLocation()
        {
            var camera = new Camera(new Algorithms(), mConfigProvider);

            camera.MoveBy(new WorldCoordinate(32, 15));

            var result1 = camera.GetLocation();

            Assert.Equal(new WorldCoordinate(32, 15), result1);
        }
    }
}
