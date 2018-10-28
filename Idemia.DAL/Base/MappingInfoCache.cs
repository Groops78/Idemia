using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Idemia.DAL.Base
{
    internal static class MappingInfoCache
    {
        private static Dictionary<string, List<PropertyMappingInfo>> cache =
            new Dictionary<string, List<PropertyMappingInfo>>();
        internal static List<PropertyMappingInfo> GetCache(string typeName)
        {
            List<PropertyMappingInfo> info = null;
            if (cache.ContainsKey(typeName))
            {
                info = (List<PropertyMappingInfo>)cache[typeName];
            }
            return info;
        }
        internal static void SetCache(string typeName, List<PropertyMappingInfo> mappingInfoList)
        {
            cache[typeName] = mappingInfoList;
        }
        public static void ClearCache()
        {
            cache.Clear();
        }
    }//end class
}//end namespace