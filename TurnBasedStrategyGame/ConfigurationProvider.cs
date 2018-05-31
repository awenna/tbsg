namespace TBSG
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public T GetValue<T>(string key)
        {
            return (T)Properties.Settings.Default[key];
        }
    }
}
