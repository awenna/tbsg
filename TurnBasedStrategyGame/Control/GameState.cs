using TBSG.Model.Hexmap;

namespace TBSG.Control
{
    public class GameState
    {
        public int TurnNumber { get; }
        public IMap Map { get; }

        public GameState(int turnNumber, IMap map)
        {
            TurnNumber = turnNumber;
            Map = map;
        }
    }
}
