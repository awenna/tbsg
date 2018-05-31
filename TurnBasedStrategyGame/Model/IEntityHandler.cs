using TBSG.Data.Abilities;
using TBSG.Data.Entities;

namespace TBSG.Model
{
    public interface IEntityHandler
    {
        bool PayFor(Entity entity, Cost cost);
        bool CanPay(Entity entity, Cost cost);
    }
}
