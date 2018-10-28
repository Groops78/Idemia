using Idemia.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idemia.Common.Entities
{
   public  class RequestType
    {
        [DataMapping("ID", 0)]
        public int? Id { get; set; }
        [DataMapping("NAME", 0)]
        public string Name { get; set; }
        [DataMapping("SCHEMAFILE", 0)]
        public string SchemaFile { get; set; }
        [DataMapping("Component", 0)]
        public string Component { get; set; }
    }
}
