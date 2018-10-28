using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idemia.Common.Entities
{
    public class EmailNotification
    {
        public int? Id { get; set; }
        public int RequestId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }
        public int StatusId { get; set; }
    }
}
