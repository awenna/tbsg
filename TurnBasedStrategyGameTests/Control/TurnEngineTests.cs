using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using NSubstitute;
using Shouldly;
using TBSG.Data;
using TBSG.Data.Control;
using TBSG.Model;
using TBSG.Model.Hexmap;
using Xunit;

namespace TBSG.Control
{
    public class TurnEngineTests
    {
        private readonly TurnEngineExtension target;
        private readonly ICommandResolver mCommandResolver;
        private readonly IMap mMap;

        public TurnEngineTests()
        {
            mMap = Substitute.For<IMap>();
            mCommandResolver = Substitute.For<ICommandResolver>();
            target = new TurnEngineExtension(mCommandResolver);
        }

        #region CompileTurn

        [Fact]
        public void CompileTurn_ResetsActions()
        {
            var action = GetDummyPlayerAction();
            target.AddAction(action);
            var state = new GameState(0, Substitute.For<IMap>());
            target.CompileTurn(state);
            Assert.Empty(target.GetActions());
        }

        [Fact]
        public void CompileTurn_IncrementsTurnCount()
        {
            var action = GetDummyPlayerAction();
            target.AddAction(action);
            var state = new GameState(7, mMap);

            var result = target.CompileTurn(state);

            result.TurnNumber.ShouldBe(8);
        }

        [Fact] //Does NOT yet account for conflicts - no checks in place
        public void CompileTurn_Always_CallsCommandResolverForEachAction()
        {
            var command1 = new Command(null, null, null, null);
            var command2 = new Command(null, null, null, null);
            var action1 = new PlayerAction(command1);
            var action2 = new PlayerAction(command2);

            var state = new GameState(5, mMap);
            target.AddAction(action1);
            target.AddAction(action2);
            target.CompileTurn(state);

            mCommandResolver.Received().Resolve(command1, mMap);
            mCommandResolver.Received().Resolve(command2, mMap);
        }

        #endregion

        private PlayerAction GetDummyPlayerAction()
        {
            return new PlayerAction(null);
        }

        internal class TurnEngineExtension : TurnEngine
        {
            public TurnEngineExtension(ICommandResolver commandResolver) : base(commandResolver) {}

            public List<PlayerAction> GetActions()
            {
                return Actions; 
            }
        }
    }
}
