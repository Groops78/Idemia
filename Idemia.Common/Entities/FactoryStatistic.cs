using Idemia.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idemia.Common.Entities
{
    public class FactoryStatistic
    {
        [DataMapping("STATUS", 0)]
        public string Status { get; set; }
        [DataMapping("COUNT", 0)]
        public int Count { get; set; }
    }
}
