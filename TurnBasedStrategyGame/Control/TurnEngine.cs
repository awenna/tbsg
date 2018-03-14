using System.Collections.Generic;
using TBSG.Data.Control;

namespace TBSG.Control
{
    public class TurnEngine
    {
        protected List<PlayerAction> Actions;

        public TurnEngine()
        {
            Actions = new List<PlayerAction>();
        }

        public void AddAction(PlayerAction action)
        {
            Actions.Add(action);
        }

        public GameState CompileTurn(GameState oldState)
        {
            Actions = new List<PlayerAction>();
            return null;
        }
    }
}
