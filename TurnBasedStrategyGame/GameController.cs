using TBSG.Data;

namespace TBSG
{
    public class GameController
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

        public void SetManualTestingMap()
        {
            var unit = new Entity();
            mMap.TileAt(new HexCoordinate(0, 0)).Entity = unit;
        }
    }
}
