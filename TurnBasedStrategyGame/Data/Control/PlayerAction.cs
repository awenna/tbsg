namespace TBSG.Data.Control
{
    public class PlayerAction
    {
        public Command Command { get; }

        public PlayerAction(Command command)
        {
            Command = command;
        }
    }
}
