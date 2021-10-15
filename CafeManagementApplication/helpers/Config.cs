using System;
using System.Configuration;


namespace CafeManagementApplication.helpers
{
    class Config
    {
        public static string GetValueFromKey(String key)
        { 
            string url = ConfigurationManager.AppSettings[key];
            return url;
        }
    }
}
