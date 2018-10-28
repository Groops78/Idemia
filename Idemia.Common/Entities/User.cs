using Idemia.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Idemia.DTO
{
    public class User
    {
        [DataMapping("ID", 0)]
        public int? Id { get; set; }
        [DataMapping("LOGIN","SYSTEM")]
        public string Login { get; set; }
        [DataMapping("EMAIL", "")]
        public string Email { get; set; }
        [DataMapping("CUSTOMERID", null)]
        public int? CustomerId { get; set; }
    }
}
