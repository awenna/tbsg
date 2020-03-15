using System;
using System.Collections.Generic;
using NSubstitute;
using Shouldly;
using Xunit;
using TBSG.Model;
using TBSG.Data;
using TBSG.Data.Abilities;
using TBSG.Data.Control;
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
            mMap = Substitute.For<IMap>();
            mCommandResolver = Substitute.For<ICommandResolver>();
            mTurnEngine = Substitute.For<ITurnEngine>();

            Target = new GameController(mMap, mCommandResolver, mTurnEngine);
        }

        #region PassTurn

        [Fact]
        public void PassTurn_AppendsNewStateToReplay()
        {
            var state = new GameState(0, null);
            var expected = new Replay(new List<GameState>{state});

            mTurnEngine.CompileTurn(null).ReturnsForAnyArgs(state);

            Target.PassTurn();

            var result = Target.GetReplay();

            expected.mGameStates.ShouldBe(result.mGameStates);
        }

        [Fact]
        public void PassTurn_UsesTurnEngine()
        {
            var expected = Target.GetGameState();

            Target.PassTurn();

            mTurnEngine.Received().CompileTurn(expected);
        }

        #endregion

        #region AddAction

        [Fact]
        public void AddAction_ValidCommand_AddedToStack()
        {
            var command = new Command(null, null, null, null);
            var action = new PlayerAction(command);

            mCommandResolver.IsValid(null, null).ReturnsForAnyArgs(true);

            Target.AddAction(action);

            mTurnEngine.Received().AddAction(action);
        }

        [Fact]
        public void AddAction_InvalidCommand_NotAdded()
        {
            var command = new Command(null, null, null, null);
            var action = new PlayerAction(command);

            mCommandResolver.IsValid(null, null).ReturnsForAnyArgs(false);

            Target.AddAction(action);

            mTurnEngine.DidNotReceive().AddAction(action);
        }

        [Fact]
        public void AddAction_InvalidCommand_DisplayMessageToUser()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void AddAction_ValidAction_AddToPlanningMap()
        {
            throw new NotImplementedException();
        }

        [Fact(Skip="Not confirmed if this will be needed")]
        public void AddAction_ValidAction_AddToLookup()
        {
            
        }

        #endregion

        #region UseDefaultAction

        [Fact]
        public void UseDefaultAction_NullParam_NoCall()
        {
            Target.UseDefaultAction(null, XY.Hex(0, 0));

            mCommandResolver.DidNotReceiveWithAnyArgs().Resolve(null, null);
        }

        [Fact]
        public void UseDefaultAction_ChecksValid()
        {
            var entity = GenerateDefaultEntity();
            var coord = XY.Hex(0, 0);

            mCommandResolver.IsValid(null, null).ReturnsForAnyArgs(false);

            Target.UseDefaultAction(entity, coord);

            mCommandResolver.DidNotReceiveWithAnyArgs().Resolve(null, null);
        }

        [Fact]
        public void UseDefaultAction_CallsTurnEngine()
        {
            var entity = GenerateDefaultEntity();
            var coord = XY.Hex(0, 0);

            mCommandResolver.IsValid(null, null).ReturnsForAnyArgs(true);

            Target.UseDefaultAction(entity, coord);

            mTurnEngine.ReceivedWithAnyArgs().AddAction(null);
        }

        #endregion

        private Entity GenerateDefaultEntity()
        {
            var ability = new Ability(Tag.TargetMode.SelfTarget, null, null);
            var entity = new Entity();
            entity.DefaultAbility = ability;
            return entity;
        }
    }
}
