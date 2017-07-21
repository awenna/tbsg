using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Rhino.Mocks;

namespace TBSG
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
            camera.MoveBy(new WorldCoordinate(-7, -2));

            var result1 = camera.GetLocation();

            Assert.Equal(new WorldCoordinate(25, 13), result1);
        }

        [Fact]
        public void GetHexesInViewe_ReturnsLowerCoordinateFirst()
        {
            var algs = MockRepository.GenerateStub<IAlgorithms>();

            algs.Stub(_ => _.WorldToHex(
                Arg<WorldCoordinate>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new HexCoordinate(2, 3))
                .Repeat.Once();
            algs.Stub(_ => _.WorldToHex(
                Arg<WorldCoordinate>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new HexCoordinate(5, 4))
                .Repeat.Once();

            var camera = new Camera(algs, mConfigProvider);

            var result = camera.GetHexesInView();

            var expected = Tuple.Create(new HexCoordinate(2, 3), new HexCoordinate(5, 4));
            Assert.Equal(expected, result);
        }
    }
}
