using TBSG.Data;
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
        private GameState CurrentGameState { get;  set; }
        private Replay mReplay { get; set; }

        private readonly IMap mMap;
        private readonly ICommandResolver mCommandResolver;
        private readonly ITurnEngine mTurnEngine;

        public GameController(
            IMap map,
            ICommandResolver commandResolver,
            ITurnEngine turnEngine)
        {
            mMap = map;
            mCommandResolver = commandResolver;
            mTurnEngine = turnEngine;

            CurrentGameState = new GameState(0, map);
            mReplay = new Replay();
        }

        public void PassTurn()
        {
            CurrentGameState = mTurnEngine.CompileTurn(CurrentGameState);
            mReplay = mReplay.AddGameState(CurrentGameState);
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

        public GameState GetGameState()
        {
            return CurrentGameState;
        }

        public IMap GetMap()
        {
            return mMap;
        }

        public Replay GetReplay()
        {
            return mReplay;
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
