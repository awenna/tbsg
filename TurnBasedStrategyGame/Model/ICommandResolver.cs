using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Data;

namespace TBSG.Model
{
    public interface ICommandResolver
    {
        void Resolve(Command command);
    }
}
