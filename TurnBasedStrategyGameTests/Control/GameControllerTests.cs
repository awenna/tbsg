using System;
using System.Collections.Generic;
using Xunit;
using Rhino.Mocks;
using TBSG.Model;
using TBSG.Data;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Data.State;
using TBSG.Model.Hexmap;

namespace TBSG.Control
{
    public class GameControllerTests
    {
        private readonly IMap mMap;
        private readonly ICommandResolver mCommandResolver;
        private readonly ITurnEngine mTurnEngine;

        private readonly GameController Target;

        public GameControllerTests()
        {
            mMap = MockRepository.GenerateStub<IMap>();
            mCommandResolver = MockRepository.GenerateStub<ICommandResolver>();
            mTurnEngine = MockRepository.GenerateMock<ITurnEngine>();

            Target = new GameController(mMap, mCommandResolver, mTurnEngine);
        }

        #region PassTurn

        [Fact]
        public void PassTurn_AppendsNewStateToReplay()
        {
            var state = new GameState(0, null);
            var expected = new Replay(new List<GameState>{state});

            mTurnEngine.Stub(
                _ => _.CompileTurn(Arg<GameState>.Is.Anything)).Return(state);

            Target.PassTurn();

            var result = Target.GetReplay();

            Assert.Equal(expected.mGameStates, result.mGameStates);
        }

        [Fact]
        public void PassTurn_UsesTurnEngine()
        {
            var expected = Target.GetGameState();

            Target.PassTurn();

            mTurnEngine.AssertWasCalled(
                _ => _.CompileTurn(expected));
        }

        [Fact]
        public void SomeOtherTypeOfCommand_IsAddedNormallyToStack()
        {
            throw new NotImplementedException();
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
            mMap.Stub(_ => _.TileAt(Arg<HexCoord>.Is.Anything)).Return(tile);

            Target.UseDefaultAction(entity, XY.Hex(0, 0));

            mCommandResolver.AssertWasCalled(x =>
                x.Resolve(Arg<Command>.Matches(_ => 
                    _.Ability == entity.DefaultAbility &&
                    _.Commandee == entity &&
                    _.TargetTile == tile)));
        }

        [Fact]
        public void UseDefaultAction_ChecksValid()
        {
            var entity = GenerateDefaultEntity();
            var coord = XY.Hex(0, 0);

            Target.UseDefaultAction(entity, coord);

            mCommandResolver.Stub(_ => _.IsValid(
                Arg<Command>.Is.Anything,
                Arg<IMap>.Is.Anything)).Return(false);

            mCommandResolver.AssertWasNotCalled(x =>
                x.Resolve(Arg<Command>.Is.Anything));
        }

        #endregion

        private Entity GenerateDefaultEntity()
        {
            return new Entity();
        }
    }
}
