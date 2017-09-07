using System.Drawing;
using Rhino.Mocks;
using Xunit;

namespace TBSG.View.Forms
{
    public class GameFormTests
    {
        private readonly IAlgorithms mAlgorithms;
        private readonly IRenderer mRenderer;
        private readonly ICameraController mCameraController;
        private readonly IPanelController mFieldPanelController;
        private readonly TestConfigurationProvider mConfigProvider;

        const int WindowWidth = 16;
        const int WindowHeight = 39;

        public GameFormTests()
        {
            mAlgorithms = new Algorithms();
            mRenderer = MockRepository.GenerateMock<IRenderer>();
            mCameraController = MockRepository.GenerateMock<ICameraController>();
            mFieldPanelController = MockRepository.GenerateMock<IPanelController>();
            mConfigProvider = new TestConfigurationProvider();
        }

        [Fact]
        public void InitializeComponent_GetsWindowSizeFromSettings()
        {
            mConfigProvider.SetValue(0, "FieldPanelSizeX");
            mConfigProvider.SetValue(0, "FieldPanelSizeY");
            mConfigProvider.SetValue(0, "InfoPanelSizeX");
            mConfigProvider.SetValue(0, "InfoPanelSizeY");
            mConfigProvider.SetValue(654, "WindowSizeX");
            mConfigProvider.SetValue(456, "WindowSizeY");

            var form = GenerateGameWindowForm();
            var result = form.Size;

            var expected = new Size(654 + WindowWidth, 456 + WindowHeight);

            Assert.Equal(expected, result);
        }
        
        private GameWindowForm GenerateGameWindowForm()
        {
            return new GameWindowForm(mAlgorithms, mRenderer, mCameraController, mFieldPanelController, mConfigProvider);
        }
    }
}
