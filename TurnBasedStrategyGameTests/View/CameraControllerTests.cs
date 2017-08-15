using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Rhino.Mocks;
using TBSG.Data;

namespace TBSG.View
{
    public class CameraControllerTests
    {
        private readonly IAlgorithms mAlgorithms;
        private readonly TestConfigurationProvider mConfigProvider;

        public CameraControllerTests()
        {
            mAlgorithms = MockRepository.GenerateStub<IAlgorithms>();
            mConfigProvider = new TestConfigurationProvider();

            mConfigProvider.SetValue(10, "CameraScaleDefault");
        }

        [Fact]
        public void Constructor_StartsCameraAtOrigo()
        {
            var controller = GenerateController();

            var result = controller.Camera.Location;

            Assert.Equal(new WorldCoordinate(0, 0), result);
        }

        [Fact]
        public void MoveBy_ChangesLocation()
        {
            var controller = GenerateController();

            controller.MoveBy(new WorldCoordinate(32, 15));
            controller.MoveBy(new WorldCoordinate(-7, -2));

            var result1 = controller.Camera.Location;

            Assert.Equal(new WorldCoordinate(25, 13), result1);
        }

        [Fact]
        public void GetHexesInViewe_ReturnsLowerCoordinateFirst()
        {
            var controller = GenerateController();

            mAlgorithms.Stub(_ => _.WorldToHex(
                Arg<WorldCoordinate>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new HexCoordinate(2, 3))
                .Repeat.Once();
            mAlgorithms.Stub(_ => _.WorldToHex(
                Arg<WorldCoordinate>.Is.Anything, Arg<int>.Is.Anything))
                .Return(new HexCoordinate(5, 4))
                .Repeat.Once();

            var result = controller.GetHexesInView();

            var expected = Tuple.Create(new HexCoordinate(2, 3), new HexCoordinate(5, 4));
            Assert.Equal(expected, result);
        }

        private CameraController GenerateController()
        {
            return new CameraController(mAlgorithms, mConfigProvider);
        }
    }
}
