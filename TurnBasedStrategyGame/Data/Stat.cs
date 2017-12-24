using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBSG.Data
{
    public class Stat
    {
        public int Cap { get; }
        public int Value { get; }

        public Stat(int value, int cap)
        {
            Value = value;
            Cap = cap;
        }

        public Stat Substract(int value)
        {
            return new Stat(Value - value, Cap);
        }
    }
}
