using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino.Mocks;
using Xunit;
using TBSG.Data;

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
        public void Apply_Move_MovesUnit()
        {
            var ability = GenerateSimpleMove();

            var entity = new Entity();
            var tile = new Tile();

            mMap.Stub(_ => _.TileAt(XY.Hex(0, 0)))
                .Return(tile);

            effectApplier.Apply(ability, entity, tile);

            Assert.True(tile.Entity == entity);
        }

        [Fact]
        public void Apply_Move_NoSpace_DoesNotMove()
        {
            var ability = GenerateSimpleMove();

            var entity = new Entity();
            var occupant = new Entity();
            var tile = new Tile { Entity = occupant };

            mMap.Stub(_ => _.TileAt(XY.Hex(0, 0)))
                .Return(tile);

            effectApplier.Apply(ability, entity, tile);

            Assert.True(tile.Entity == occupant);
        }

        #region Helpers

        private Effect GenerateSimpleMove()
        {
            return new Effect { Tag = Tag.Effects.Movement, Value = 2 };
        }

        #endregion
    }
}
