using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedStrategyGame
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

        public void Initialize()
        {
            mMap.GenerateMap(new Coordinate(1, 1));
        }
    }
}
