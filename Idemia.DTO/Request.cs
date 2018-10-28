using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idemia.DTO
{
    public class Request
    {
        public int Id { get; set; }
        public int RequestTypeId { get; set; }
        public int CustomerId { get; set; }
        public int? StatusId { get; set; }
        public string Priority { get; set; }
        public int Order { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
