using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Idemia.Common.Helpers
{
   public  class NullValues
    {
        public static DateTime NullDateTime = DateTime.MinValue;
        public static Guid NullGuid = Guid.Empty;
        public static int NullInt = int.MinValue;
        public static float NullFloat = float.MinValue;
        public static decimal NullDecimal = decimal.MinValue;
        public static double NullDouble = double.MinValue;
        public static string NullString = null;
    }
}
