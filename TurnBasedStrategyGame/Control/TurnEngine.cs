using System.Collections.Generic;
using TBSG.Data.Control;
using TBSG.Model;
using TBSG.Model.Hexmap;

namespace TBSG.Control
{
    public class TurnEngine : ITurnEngine
    {
        private ICommandResolver mCommandResolver;
        protected List<PlayerAction> Actions;

        public TurnEngine(ICommandResolver commandResolver)
        {
            mCommandResolver = commandResolver;
            Actions = new List<PlayerAction>();
        }

        public void AddAction(PlayerAction action)
        {
            Actions.Add(action);
        }

        public GameState CompileTurn(GameState oldState)
        {
            var map = oldState.Map;
            Actions.ForEach(_ => ApplyAction(_, map));

            ResetActionList();
            var newState = new GameState(oldState.TurnNumber + 1, map);
            return newState;
        }

        private void ApplyAction(PlayerAction action, IMap map)
        {
            mCommandResolver.Resolve(action.Command, map);
        }

        private void ResetActionList()
        {
            Actions = new List<PlayerAction>();
        }
    }
}
