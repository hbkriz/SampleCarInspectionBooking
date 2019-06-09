using System.Configuration;

namespace ServiceInspection.Wrappers
{
    public class ConfigurationManagerWrapper: IConfigurationManagerWrapper
    {
        public string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}