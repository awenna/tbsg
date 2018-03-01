using System;
using System.Collections.Generic;
using TBSG.Data.Control;
using Xunit;

namespace TBSG.Control
{
    public class TurnEngineTests
    {
        private readonly TurnEngine target;

        public TurnEngineTests()
        {
            target = new TurnEngine();
        }

        [Fact]
        public void CompileTurn_ResetsActions()
        {
            throw new NotImplementedException();
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
