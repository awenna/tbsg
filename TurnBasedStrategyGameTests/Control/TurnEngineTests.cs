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
            var state = new GameState();
            target.CompileTurn(state);
            Assert.Empty(target.GetActions());
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
