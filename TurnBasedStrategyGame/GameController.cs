using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedStrategyGame
{
    public class GameController
    {
        private readonly IGui mGui;
        private readonly IMap mMap;
        private readonly IPlayer mPlayer;

        public GameController(
            IGui gui,
            IMap map,
            IPlayer player)
        {
            mGui = gui;
            mMap = map;
            mPlayer = player;
        }

        public void Initialize()
        {
            mMap.GenerateMap(1, 1);
        }
    }
}
