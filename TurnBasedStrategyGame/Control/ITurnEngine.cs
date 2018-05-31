using TBSG.Data.Control;

namespace TBSG.Control
{
    public interface ITurnEngine
    {
        void AddAction(PlayerAction action);
        GameState CompileTurn(GameState oldState);
    }
}
