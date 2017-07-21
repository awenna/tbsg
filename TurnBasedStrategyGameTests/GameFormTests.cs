using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Rhino.Mocks;
using Xunit;

namespace TBSG
{
    public class GameFormTests
    {
        private readonly TestConfigurationProvider mConfigProvider;
        private readonly IRenderer mRenderer;
        private readonly ICamera mCamera;

        public GameFormTests()
        {
            mConfigProvider = new TestConfigurationProvider();
            mRenderer = MockRepository.GenerateMock<IRenderer>();
            mCamera = MockRepository.GenerateMock<ICamera>();
        }

        [Fact]
        public void InitializeComponent_GetsWindowSizeFromSettings()
        {
            mConfigProvider.SetValue(0, "FieldPanelSizeX");
            mConfigProvider.SetValue(0, "FieldPanelSizeY");
            mConfigProvider.SetValue(654, "WindowSizeX");
            mConfigProvider.SetValue(456, "WindowSizeY");

            var form = new GameWindowForm(mRenderer, mCamera, mConfigProvider);

            var result = form.Size;

            var expected = new Size(654 + 16, 456 + 39);

            Assert.Equal(expected, result);
        }
    }
}
