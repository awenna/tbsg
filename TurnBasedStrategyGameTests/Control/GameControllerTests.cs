using System;
using Xunit;
using Rhino.Mocks;
using TBSG.Model;
using TBSG.Data;

namespace TBSG.Control
{
    public class GameControllerTests
    {
        private readonly IMap mMap;
        private readonly ICommandResolver mCommandResolver;

        public GameControllerTests()
        {
            mMap = MockRepository.GenerateStub<IMap>();
            mCommandResolver = MockRepository.GenerateStub<ICommandResolver>();
        }

        [Fact]
        public void UseDefaultAction_NullParam_NoCall()
        {
            var controller = GetGameController();

            controller.UseDefaultAction(null, XY.Hex(0, 0));

            mCommandResolver.AssertWasNotCalled(x =>
                x.Resolve(Arg<Command>.Is.Anything));
        }

        [Fact]
        public void UseDefaultAction_UnitSelected_CreateCommandForDefaultAction()
        {
            var controller = GetGameController();

            var entity = GenerateDefaultEntity();

            var tile = new Tile();
            mMap.Stub(_ => _.TileAt(Arg<HexCoordinate>.Is.Anything)).Return(tile);

            var expectedCommand = new Command
            {
                Commandee = entity,
                Ability = entity.DefaultAbility
            };

            controller.UseDefaultAction(entity, XY.Hex(0, 0));

            mCommandResolver.AssertWasCalled(x =>
                x.Resolve(Arg<Command>.Matches(_ => 
                    _.Ability == entity.DefaultAbility &&
                    _.Commandee == entity &&
                    _.TargetTile == tile)));
        }

        private Entity GenerateDefaultEntity()
        {
            return new Entity
            {
                DefaultAbility = new Ability()
            };
        }

        private GameController GetGameController()
        {
            return new GameController(mMap, mCommandResolver);
        }
    }
}
