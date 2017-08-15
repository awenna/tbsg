using System;
using TBSG.Data;
using TBSG.Model;
using TBSG.View;

namespace TBSG.Control
{
    public class GameController : IGameController
    {
        private readonly IMap mMap;
        private readonly IPlayer mPlayer;

        public GameController(
            IMap map,
            IPlayer player)
        {
            mMap = map;
            mPlayer = player;
        }

        public void UseDefaultAction(ViewState state)
        {
            throw new NotImplementedException();
        }

        public IMap GetMap()
        {
            return mMap;
        }

        #region Manual Testing

        public void SetManualTestingMap()
        {
            var unit = new Entity();
            mMap.TileAt(new HexCoordinate(0, 0)).Entity = unit;
        }

        #endregion
    }
}
