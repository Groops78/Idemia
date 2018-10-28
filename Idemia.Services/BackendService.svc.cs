using Idemia.Common.Entities;
using Idemia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Idemia.Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]

    public class BackendService : IBackendService
    {
        RequestDao dao = new RequestDao();
        public List<Request> GetRequests()
        {
            List<Request> requests = dao.GetRequests();
            return requests;
        }

       public string SaveRequest(Request request)
        {
            return dao.SaveRequest(request) ? "Success" : "Fail";
        }

       public Request GetNextRequest()
        {
            return dao.GetNextRequest();
        }

       public string TransitionRequest(string id, string statusId, string notifyCustomer, string notifyManager)
        {
            int Id = 0;
            bool notifycustomer, notifymanager = false;
            notifycustomer = notifyCustomer.ToLower().Contains("t") || notifyCustomer.ToLower().Contains("1");
            notifymanager = notifyManager.ToLower().Contains("f") || notifyManager.ToLower().Contains("1") ;
            int.TryParse(id, out Id);
            Request request = dao.GetRequests(Id).First();
            request.Modified = DateTime.Now;
            request.ModifiedBy = 2;//hard coded by as machine
            request.StatusId = int.Parse(statusId);
            dao.SaveRequest(request);
            if (notifycustomer) {
                EmailNotification notification = new EmailNotification() {  RequestId = request.Id.Value, StatusId=request.StatusId.Value, To=request.Email, Subject="Request "+id.ToString()+" Updated", Body="body"};
                dao.SaveEmailNotification(notification);
            }

            if (notifymanager)
            {
                EmailNotification notification = new EmailNotification() { RequestId = request.Id.Value, StatusId = request.StatusId.Value, To = "manager@email.com", Subject = "Request " + id.ToString() + " Updated", Body = "body" };
                dao.SaveEmailNotification(notification);
            }
            return "Done!";
        }


       public List<RequestStatus> GetRequestStatuses()
        {
            return dao.GetRequestStatuses();
        }


       public List<FactoryStatistic> GetFactoryStats(string from, string to)
        {
           return dao.GetFactoryStatistics();
        }


        public void ClearInProgress()
        {
             dao.ClearInProgress();
        }


        public void StartManufacturing()
        {
            Request request =GetNextRequest();


        }
    }
}
