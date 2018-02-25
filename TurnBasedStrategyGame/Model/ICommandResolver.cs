using TBSG.Data;

namespace TBSG.Model
{
    public interface ICommandResolver
    {
        void Resolve(Command command);
    }
}
