using Idemia.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Idemia.Services
{
    [ServiceContract]
    public interface IBackendService
    {
        [WebGet]
        [OperationContract]
        List<Request> GetRequests();

        [WebGet]
        [OperationContract]
        List<RequestStatus> GetRequestStatuses();

        [WebInvoke(Method="POST")]
        [OperationContract]
        string SaveRequest(Request request);

        [WebGet]
        [OperationContract]
        Request GetNextRequest();

        [WebGet(UriTemplate = "next/{id}/{statusId}/{notifyCustomer}/{notifyManager}")]
        [OperationContract]
        string TransitionRequest(string id, string statusId, string notifyCustomer, string notifyManager);
        
        [WebGet]
        [OperationContract]
        List<FactoryStatistic> GetFactoryStats(string from, string to);

        [WebGet]
        [OperationContract]
        void ClearInProgress();

        [WebGet]
        [OperationContract]
        void StartManufacturing();
    }

}
