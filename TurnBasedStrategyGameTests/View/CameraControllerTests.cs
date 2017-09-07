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

        private readonly CameraController Target;

        public CameraControllerTests()
        {
            mAlgorithms = MockRepository.GenerateStub<IAlgorithms>();
            mConfigProvider = new TestConfigurationProvider();

            mConfigProvider.SetValue(10, "CameraScaleDefault");

            Target = new CameraController(mAlgorithms, mConfigProvider);
        }

        [Fact]
        public void Constructor_StartsCameraAtOrigo()
        {
            var result = Target.Camera.Location;

            Assert.Equal(new WorldCoordinate(0, 0), result);
        }

        [Fact]
        public void MoveBy_ChangesLocation()
        {
            Target.MoveBy(new WorldCoordinate(32, 15));
            Target.MoveBy(new WorldCoordinate(-7, -2));

            var result1 = Target.Camera.Location;

            Assert.Equal(new WorldCoordinate(25, 13), result1);
        }

        [Fact]
        public void GetHexesInView_CallsWithExtraSpace()
        {
            mAlgorithms.Stub(_ => _.WorldToHex(
                Arg<WorldCoordinate>.Is.Anything, Arg<int>.Is.Anything))
                .Return(XY.Hex(2, 3))
                .Repeat.Times(2);
            mAlgorithms.Stub(_ => _.ScreenToWorld(
                Arg<ScreenCoordinate>.Is.Anything, Arg<Coordinate>.Is.Anything))
                .Return(XY.World(0, 0))
                .Repeat.Once();

            Target.GetHexesInView();

            mAlgorithms.AssertWasCalled(_ => _.Get2DRange(
                XY.Hex(1, 2), XY.Hex(3, 4)));
        }
    }
}
