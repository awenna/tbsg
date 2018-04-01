﻿using TBSG.Data;
using TBSG.Data.Abilities;
using TBSG.Data.Entities;
using TBSG.Data.Hexmap;
using TBSG.Data.State;
using TBSG.Model;
using TBSG.Model.Hexmap;

namespace TBSG.Control
{
    public class GameController : IGameController
    {
        public GameState CurrentGameState { get; private set; }
        private Replay mReplay { get; set; }

        private readonly IMap mMap;
        private readonly ICommandResolver mCommandResolver;
        private readonly ITurnEngine mTurnEngine;

        public GameController(
            IMap map,
            ICommandResolver commandResolver)
        {
            mMap = map;
            mCommandResolver = commandResolver;

            CurrentGameState = new GameState(0, null);
        }

        public void PassTurn()
        {
            
        }

        public void UseDefaultAction(Entity entity, HexCoordinate targetLocation)
        {
            if (entity == null) return;

            var command = new Command(
                entity,
                null,
                mMap.TileAt(targetLocation),
                entity.DefaultAbility
            );

            mCommandResolver.Resolve(command);
        }

        public IMap GetMap()
        {
            return mMap;
        }

        #region Manual Testing

        public void SetManualTestingMap()
        {
            var moveEff = new Effect
            {
                Tag = Tag.Effects.Movement,
                Value = 2
            };
            var moveTargetted = new TargettedEffect
            {
                Target = Tag.Target.SelfAndGround,
                Effect = moveEff
            };
            var moveAbility = new Ability
            {
                TargetMode = Tag.TargetMode.GroundTarget,
                Effects = new[] { moveTargetted }
            };

            var entity = new Entity { DefaultAbility = moveAbility };
            mMap.MoveEntityTo(entity, mMap.TileAt(new HexCoordinate(0, 0)));
        }

        #endregion
    }
}
