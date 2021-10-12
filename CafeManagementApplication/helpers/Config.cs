using System;
using System.Configuration;


namespace CafeManagementApplication.helpers
{
    class Config
    {
        public static String GetValueFromKey(String key)
        { 
            String url = ConfigurationManager.AppSettings[key];
            return url;
        }
    }
}
