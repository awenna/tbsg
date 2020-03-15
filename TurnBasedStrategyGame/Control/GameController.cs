using TBSG.Data;
using TBSG.Data.Abilities;
using TBSG.Data.Control;
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
        private Replay Replay { get; set; }

        private readonly IMap mMap;
        private readonly IMap mPlanningMap;
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
            Replay = new Replay();
        }

        public void PassTurn()
        {
            CurrentGameState = mTurnEngine.CompileTurn(CurrentGameState);
            Replay = Replay.AddGameState(CurrentGameState);
        }

        public void AddAction(PlayerAction action)
        {
            if (mCommandResolver.IsValid(action.Command, mMap))
            {
                mTurnEngine.AddAction(action);
            }
        }

        public void UseDefaultAction(Entity entity, HexCoord targetLocation)
        {
            if (entity == null) return;

            var command = new Command(
                entity,
                null,
                mMap.TileAt(targetLocation),
                entity.DefaultAbility
            );

            var action = new PlayerAction(command);

            AddAction(action);
        }

        public GameState GetGameState()
        {
            return CurrentGameState;
        }

        public IMap GetMap()
        {
            return mMap;
        }

        public IMap GetPlanMap()
        {
            return mPlanningMap;
        }

        public Replay GetReplay()
        {
            return Replay;
        }

        #region Manual Testing

        public void SetManualTestingMap()
        {
            var moveEff = new Effect
            {
                Tag = Tag.Effects.Movement
            };
            var moveTargetted = new TargettedEffect(
                Tag.Target.SelfAndGround,
                moveEff);

            var moveAbility = new Ability(
                    Tag.TargetMode.GroundTarget,
                    new[] { moveTargetted },
                    new []
                    {
                        new Limitation(Tag.Limitation.Range, 2) 
                    }
                );

            var entity = new Entity { DefaultAbility = moveAbility };
            mMap.MoveEntityTo(entity, mMap.TileAt(new HexCoord(0, 0)));
        }

        #endregion
    }
}
