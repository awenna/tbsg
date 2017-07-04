using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedStrategyGame
{
    public interface IConfigurationProvider
    {
        T GetValue<T>(string configurationKey);
    }
}
