namespace TBSG.Control
{
    public class GameState
    {
        public int PlayerTurn { get; private set; }
        public int TurnNumber { get; private set; }

        public GameState NextTurn()
        {
            return new GameState
            {
                TurnNumber = TurnNumber + 1,
            };
        }
    }
}
