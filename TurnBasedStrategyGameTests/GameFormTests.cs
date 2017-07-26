using System.Drawing;
using Rhino.Mocks;
using Xunit;

namespace TBSG.View
{
    public class GameFormTests
    {
        private readonly IAlgorithms mAlgorithms;
        private readonly IRenderer mRenderer;
        private readonly ICamera mCamera;
        private readonly TestConfigurationProvider mConfigProvider;

        public GameFormTests()
        {
            mAlgorithms = new Algorithms();
            mRenderer = MockRepository.GenerateMock<IRenderer>();
            mCamera = MockRepository.GenerateMock<ICamera>();
            mConfigProvider = new TestConfigurationProvider();
        }

        [Fact]
        public void InitializeComponent_GetsWindowSizeFromSettings()
        {
            mConfigProvider.SetValue(0, "FieldPanelSizeX");
            mConfigProvider.SetValue(0, "FieldPanelSizeY");
            mConfigProvider.SetValue(654, "WindowSizeX");
            mConfigProvider.SetValue(456, "WindowSizeY");

            var form = new GameWindowForm(mAlgorithms, mRenderer, mCamera, mConfigProvider);

            var result = form.Size;

            var expected = new Size(654 + 16, 456 + 39);

            Assert.Equal(expected, result);
        }
    }
}
