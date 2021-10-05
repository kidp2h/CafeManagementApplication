using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using MongoDB.Driver;

namespace CafeManagementApplication.helpers
{
    class Config
    {
        public String GetValueFromKey(String key)
        { 
            String url = ConfigurationManager.AppSettings[key];
            return url;
        }
    }
}
