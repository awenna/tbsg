using System;
using Xunit;
using Rhino.Mocks;

namespace TurnBasedStrategyGame
{
    public class GameControllerTests
    {
        private readonly IMap mMap;
        private readonly IPlayer mPlayer;
        private readonly IConfigurationProvider mConfigurationProvider;

        public GameControllerTests()
        {
            mMap = MockRepository.GenerateStub<IMap>();
            mPlayer = MockRepository.GenerateStub<IPlayer>();
            mConfigurationProvider = MockRepository.GenerateStub<IConfigurationProvider>();
        }

        [Fact]
        public void Constructor_RequiresMap()
        {
            var game = new GameController(mMap, mPlayer);
        }
    }
}
