using System.Collections.Generic;
using TBSG.Data.Control;
using Xunit;

namespace TBSG.Control
{
    public class TurnEngineTests
    {
        private readonly TurnEngineExtension target;

        public TurnEngineTests()
        {
            target = new TurnEngineExtension();
        }

        [Fact]
        public void CompileTurn_ResetsActions()
        {
            target.AddAction(null);
            var state = new GameState(0, null);
            target.CompileTurn(state);
            Assert.Empty(target.GetActions());
        }

        [Fact]
        public void CompileTurn_IncrementsTurnCount()
        {
            target.AddAction(null);
            var state = new GameState(7, null);
            var result = target.CompileTurn(state);
            Assert.Equal(8, result.TurnNumber);
        }

        internal class TurnEngineExtension : TurnEngine
        {
            public List<PlayerAction> GetActions()
            {
                return Actions; 
            }
        }
    }
}
