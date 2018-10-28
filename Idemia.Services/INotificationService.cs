using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Idemia.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "INotificationService" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required,
      CallbackContract = typeof(ISuscribeClientContract))]
    public interface INotificationService
    {
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Subscribe();
        [OperationContract(IsOneWay = false, IsTerminating = true)]
        void Unsubscribe();
        [OperationContract(IsOneWay = true)]
        void PublishMachineChange(int requestId, int statusId, int progress, string state);
   
    }

    public interface ISuscribeClientContract
    {
        [OperationContract(IsOneWay = true)]
        void MachineChange(int requestId, int statusId,int progress, string state );
    }  
}
