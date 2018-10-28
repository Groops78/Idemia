using Idemia.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Idemia.Common.Entities
{
    public enum RequestStatusType
    {
       New=1, Deferred=2, Schduled=3, InProgress=4, DonePendingDelivery=5,  Delivered=6, Paused=7, Error=8
    }

    public class RequestStatus
    {
        [DataMapping("ID", 0)]
        public int? Id { get; set; }
        [DataMapping("NAME", 0)]
        public string Name { get; set; }
        [DataMapping("NEXTSTATUSID", 0)]
        public int? NextStatusId { get; set; }
        [DataMapping("NOTIFYCUSTOMER", 0)]
        public int NotifyCustomer { get; set; }
        [DataMapping("NOTIFYMANAGER", 0)]
        public int NotifyManager { get; set; }
        [DataMapping("DURATION", 3)]
        public int Duration { get; set; }
        public RequestStatusType ReuqestStatusType { get { return (RequestStatusType)Id; } }
   

    }
}
