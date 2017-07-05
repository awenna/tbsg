using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedStrategyGame
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public T GetValue<T>(string key)
        {
            return (T)Properties.Settings.Default[key];
        }
    }
}
