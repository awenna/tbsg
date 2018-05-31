using Rhino.Mocks;
using Xunit;
using TBSG.Data;
using TBSG.Data.Abilities;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Model.Hexmap;

namespace TBSG.Model
{
    public class EffectApplierTests
    {
        private readonly IMap mMap;

        private readonly EffectApplier effectApplier;

        public EffectApplierTests()
        {
            mMap = MockRepository.GenerateStub<IMap>();

            effectApplier = new EffectApplier(mMap);
        }

        [Fact]
        public void Apply_Movement_MovesUnit()
        {
            var effect = GenerateSimpleMove();

            var entity = new Entity();
            var tile = new Tile();

            effectApplier.Apply(effect, entity, tile);

            mMap.AssertWasCalled(_ => _
                .MoveEntityTo(entity, tile));
        }

        #region Helpers

        private Effect GenerateSimpleMove()
        {
            return new Effect { Tag = Tag.Effects.Movement, Value = 2 };
        }

        #endregion
    }
}
