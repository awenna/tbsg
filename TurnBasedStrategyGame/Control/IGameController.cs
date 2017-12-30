using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Model.Hexmap;

namespace TBSG.Control
{
    public interface IGameController
    {
        IMap GetMap();
        void UseDefaultAction(Entity entity, HexCoordinate targetLocation);
    }
}
