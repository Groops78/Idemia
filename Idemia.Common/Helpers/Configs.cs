using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Idemia.Common.Helpers
{
    public class Configs
    {
        public static string ConnectionString = "IdemiaConnectionString";
        static Configs()
        {
            ConnectionString = GetConnectionStringValue("IdemiaConnectionString");
        }
        private static string GetConnectionStringValue(string key)
        {
            string value = null;
            if (ConfigurationManager.ConnectionStrings[key] != null)
            {
                value = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            return value;
        }
        private static string GetAppConfigValue(string key, string defaultvalue)
        {
            string result = defaultvalue;
            try { if (ConfigurationManager.AppSettings[key] != null) result = ConfigurationManager.AppSettings[key].ToString(); }
            catch { }
            return result;
        }
    }
}
