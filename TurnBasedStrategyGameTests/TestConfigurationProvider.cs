using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedStrategyGame
{
    public class TestConfigurationProvider : IConfigurationProvider
    {
        private Dictionary<string, object> mDictionary;

        public TestConfigurationProvider()
        {
            mDictionary = new Dictionary<string, object>();
        }

        public T GetValue<T>(string key)
        {
            return (T)mDictionary[key];
        }

        public void SetValue(object value, string key)
        {
            mDictionary.Add(key, value);
        }
    }
}
