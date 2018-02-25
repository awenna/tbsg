using Xunit;
using Rhino.Mocks;
using TBSG.Model;
using TBSG.Data;
using TBSG.Data.Abilities;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Model.Hexmap;

namespace TBSG.Control
{
    public class GameControllerTests
    {
        private readonly IMap mMap;
        private readonly ICommandResolver mCommandResolver;

        private readonly GameController Target;

        public GameControllerTests()
        {
            mMap = MockRepository.GenerateStub<IMap>();
            mCommandResolver = MockRepository.GenerateStub<ICommandResolver>();

            Target = new GameController(mMap, mCommandResolver);
        }

        #region PassTurn

        [Fact]
        public void PassTurn_UpdatesGameState()
        {
            Target.PassTurn();

            Assert.Equal(1, Target.GameState.TurnNumber);
        }

        #endregion

        #region UseDefaultAction

        [Fact]
        public void UseDefaultAction_NullParam_NoCall()
        {
            Target.UseDefaultAction(null, XY.Hex(0, 0));

            mCommandResolver.AssertWasNotCalled(x =>
                x.Resolve(Arg<Command>.Is.Anything));
        }

        [Fact]
        public void UseDefaultAction_UnitSelected_CreateCommandForDefaultAction()
        {
            var entity = GenerateDefaultEntity();

            var tile = new Tile();
            mMap.Stub(_ => _.TileAt(Arg<HexCoordinate>.Is.Anything)).Return(tile);

            Target.UseDefaultAction(entity, XY.Hex(0, 0));

            mCommandResolver.AssertWasCalled(x =>
                x.Resolve(Arg<Command>.Matches(_ => 
                    _.Ability == entity.DefaultAbility &&
                    _.Commandee == entity &&
                    _.TargetTile == tile)));
        }

        #endregion

        private Entity GenerateDefaultEntity()
        {
            return new Entity
            {
                DefaultAbility = new Ability()
            };
        }
    }
}
