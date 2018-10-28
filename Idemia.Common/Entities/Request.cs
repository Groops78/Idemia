using Idemia.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Idemia.Common.Entities
{
    public class Request
    {
        [DataMapping("ID", 0)]
        public int? Id { get; set; }
        [DataMapping("REQUESTTYPEID", null)]
        public int RequestTypeId { get; set; }
        [DataMapping("CUSTOMER", null)]
        public string Customer { get; set; }
        [DataMapping("STATUS", null)]
        public string Status { get; set; }
        [DataMapping("EMAIL", null)]
        public string Email { get; set; }
        [DataMapping("ADDRESS", null)]
        public string Address { get; set; }
        [DataMapping("CUSTOMERID", null)]
        public int CustomerId { get; set; }
        [DataMapping("STATUSID", null)]
        public int? StatusId { get; set; }
         [DataMapping("REQUESTDETAILS", null)]
        public string RequestDetails { get; set; }
        [DataMapping("PRIORITY", null)]
        public string Priority { get; set; }
        [DataMapping("REQUESTORDER", null)]
        public int Order { get; set; }
        [DataMapping("CREATEDBY", null)]
        public int? CreatedBy { get; set; }
        [DataMapping("CREATED", null)]
        public DateTime? Created { get; set; }
        [DataMapping("MODIFIEDBY", null)]
        public int? ModifiedBy { get; set; }
        [DataMapping("MODIFIED", null)]
        public DateTime? Modified { get; set; }
    }
}
//STATEPROGRESS
//OVERALLPROGRESS
