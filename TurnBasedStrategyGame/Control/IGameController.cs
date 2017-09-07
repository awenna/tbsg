using TBSG.Model;
using TBSG.Data;

namespace TBSG.Control
{
    public interface IGameController
    {
        IMap GetMap();
        void UseDefaultAction(Entity entity, HexCoordinate targetLocation);
    }
}
