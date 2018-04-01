using System.Collections.Generic;
using TBSG.Control;

namespace TBSG.Data.State
{
    public class Replay
    {
        public readonly List<GameState> mGameStates;

        public Replay(List<GameState> gameStates = null)
        {
            mGameStates = gameStates ?? new List<GameState>();
        }

        public Replay AddGameState(GameState gameState)
        {
            var newList = mGameStates;
            newList.Add(gameState);
            var newReplay = new Replay();
            return newReplay;
        }
    }
}
