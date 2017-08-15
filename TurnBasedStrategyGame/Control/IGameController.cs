using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.Model;
using TBSG.View;

namespace TBSG.Control
{
    public interface IGameController
    {
        IMap GetMap();
        void UseDefaultAction(ViewState state);
    }
}
