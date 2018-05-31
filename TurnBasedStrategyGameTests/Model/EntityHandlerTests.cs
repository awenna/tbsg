using Xunit;
using TBSG.Data;
using TBSG.Data.Abilities;
using TBSG.Data.Entities;

namespace TBSG.Model
{
    public class EntityHandlerTests
    {
        private readonly EntityHandler Target;

        public EntityHandlerTests()
        {
            Target = new EntityHandler();
        }

        #region CanPay

        [Fact]
        public void CanPay_NotEnoughResources_ReturnsFalse()
        {
            var stat = new Stat(4, 4);
            var entity = new Entity { ActionPoints = stat };
            var cost = new Cost(Tag.Cost.ActionPoint, 5);

            Assert.False(Target.CanPay(entity, cost));
        }

        [Fact]
        public void CanPay_EnoughResources_ReturnsTrue()
        {
            var stat = new Stat(3, 3);
            var entity = new Entity { ActionPoints = stat };
            var cost = new Cost(Tag.Cost.ActionPoint, 2);

            Assert.True(Target.CanPay(entity, cost));
        }

        #endregion

        #region PayFor

        [Fact]
        public void PayFor_EnoughResources_ReducesCostFromEntityAndReturnsTrue()
        {
            var stat = new Stat(3, 3);
            var entity = new Entity { ActionPoints = stat };
            var cost = new Cost(Tag.Cost.ActionPoint, 2);

            var result = Target.PayFor(entity, cost);

            Assert.True(result);
            Assert.Equal(1, entity.ActionPoints.Value);
        }

        [Fact]
        public void PayFor_NotEnough_NoActionAndReturnsFalse()
        {
            var stat = new Stat(3, 3);
            var entity = new Entity { ActionPoints = stat };
            var cost = new Cost(Tag.Cost.ActionPoint, 5);

            var result = Target.PayFor(entity, cost);

            Assert.False(result);
            Assert.Equal(3, entity.ActionPoints.Value);

        }

        #endregion
    }
}
