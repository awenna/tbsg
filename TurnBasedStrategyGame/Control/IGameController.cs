using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Model.Hexmap;

namespace TBSG.Control
{
    public interface IGameController
    {
        GameState GetGameState();
        IMap GetMap();
        void UseDefaultAction(Entity entity, HexCoordinate targetLocation);
        void PassTurn();
    }
}
