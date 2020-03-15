using Rhino.Mocks;
using TBSG.Control;
using Xunit;

namespace TBSG.View
{
    public class ViewControllerTests
    {
        private readonly ViewController target;

        private readonly IAlgorithms mAlgorithms;
        private readonly ICameraController mCameraController;
        private readonly IGameController mGameController;
        private readonly IRenderer mRenderer;

        public ViewControllerTests()
        {
            mAlgorithms = MockRepository.GenerateMock<IAlgorithms>();
            mCameraController = MockRepository.GenerateMock<ICameraController>();
            mGameController = MockRepository.GenerateMock<IGameController>();
            mRenderer = MockRepository.GenerateMock<IRenderer>();

            target = new ViewController(mAlgorithms, mCameraController, mGameController, mRenderer);
        }

        [Fact]
        public void PassTurn_CallsGameControllerPassTurn()
        {
            target.PassTurn();
            mGameController.AssertWasCalled(
                _=>_.PassTurn());
        }

        [Fact]
        public void PassTurn_GetsNewGameStateFromController()
        {
            var expected = new GameState(10, null);
            mGameController.Stub(_ => _.GetGameState()).Return(expected);

            target.PassTurn();

            mGameController.AssertWasCalled(
                _ => _.GetGameState());

            Assert.Same(expected, target.GetGameState());
        }
    }
}
