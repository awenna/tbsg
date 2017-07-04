using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace TurnBasedStrategyGame
{
    [TestClass]
    public class GameControllerTests
    {
        private readonly IGui mGui;
        private readonly IMap mMap;
        private readonly IPlayer mPlayer;
        private readonly IConfigurationProvider mConfigurationProvider;

        public GameControllerTests()
        {
            mGui = MockRepository.GenerateStub<IGui>();
            mMap = MockRepository.GenerateStub<IMap>();
            mPlayer = MockRepository.GenerateStub<IPlayer>();
            mConfigurationProvider = MockRepository.GenerateStub<IConfigurationProvider>();
        }

        [TestMethod]
        public void Constructor_RequiresMap()
        {
            var game = new GameController(mGui, mMap, mPlayer);
        }

        [TestMethod]
        public void Initialize_CallsMapGeneration()
        {
            var game = new GameController(mGui, mMap, mPlayer);

            game.Initialize();

            mMap.AssertWasCalled(_ => _.GenerateMap(
                Arg<int>.Is.Anything,
                Arg<int>.Is.Anything));
        }
    }
}
