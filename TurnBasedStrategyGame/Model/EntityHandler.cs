using TBSG.Data;

namespace TBSG.Model
{
    public class EntityHandler
    {
        public bool CanPay(Entity entity, Cost cost)
        {
            switch (cost.Type)
            {
                case Tag.Cost.ActionPoint:
                    return entity.ActionPoints.Value >= cost.Value;
                default:
                    return false;
            }
        }

        public bool PayFor(Entity entity, Cost cost)
        {
            if (!CanPay(entity, cost)) return false;
            switch (cost.Type)
            {
                case Tag.Cost.ActionPoint:
                    entity.ActionPoints = entity.ActionPoints.Substract(cost.Value);
                    return true;
                default:
                    return false;
            }
        }
    }
}
