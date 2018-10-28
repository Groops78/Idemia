using Idemia.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idemia.Common.Entities
{
    public class Customer
    {
        [DataMapping("ID", 0)]
        public int? Id { get; set; }
        [DataMapping("NAME", 0)]
        public string Name { get; set; }
        [DataMapping("EMAIL", 0)]
        public string Email { get; set; }
        [DataMapping("ADDRESS", 0)]
        public string Address { get; set; }

    }
}
