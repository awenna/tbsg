using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBSG.Data
{
    public class Cost
    {
        public Tag.Cost Type { get; }
        public int Value { get; }

        public Cost (Tag.Cost type, int value)
        {
            Type = type;
            Value = value;
        }
    }
}
