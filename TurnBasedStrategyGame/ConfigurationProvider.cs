using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBasedStrategyGame.Properties;

namespace TBSG
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public T GetValue<T>(string key)
        {
            return (T)Settings.Default[key];
        }
    }
}
