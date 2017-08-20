using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBSG.View;

namespace TBSG.Data
{
    public class ViewState
    {
        public ISelection Selection { get; set; }
        public Camera Camera { get; set; }
    }
}
