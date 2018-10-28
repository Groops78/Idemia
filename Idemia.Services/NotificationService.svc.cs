using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Idemia.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]  
    public class NotificationService : INotificationService
    {
        public static event MachineChangeEventHandler MachineChangeEvent;
        public delegate void MachineChangeEventHandler(object sender, MachineChangeEventArgs e);

        ISuscribeClientContract callback = null;

        MachineChangeEventHandler machineChangeHandler = null;

        

        public void Subscribe()
        {
            callback = OperationContext.Current.GetCallbackChannel<ISuscribeClientContract>();
            machineChangeHandler = new MachineChangeEventHandler(MachineChangeHandler);
            MachineChangeEvent += machineChangeHandler;
        }

  

        public void Unsubscribe()
        {
            MachineChangeEvent -= machineChangeHandler;
        }

     
        /// <summary>
        /// Indicate a chnage in an order/request change of status or order
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="statusId"></param>
        /// <param name="progress"></param>
        public void PublishMachineChange(int requestId, int statusId, int progress, string state)
        {
            MachineChangeEventArgs e = new MachineChangeEventArgs();
            e.RequestId = requestId;
            e.StatusId = statusId;
            e.Progress = progress;
            e.State = state;
            MachineChangeEvent(this, e);
        }

        //This event handler runs when a PriceChange event is raised.  
        //The client's PriceChange service operation is invoked to provide notification about the price change.  

        public void MachineChangeHandler(object sender, MachineChangeEventArgs e)
        {
            callback.MachineChange(e.RequestId, e.StatusId, e.Progress, e.State);
        }  
    }

    public class MachineChangeEventArgs : EventArgs
    {
        public int RequestId;
        public int StatusId;
        public int Progress;
        public string State;// Machine state
    }  
}
