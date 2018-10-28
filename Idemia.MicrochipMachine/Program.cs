using Idemia.Common.Entities;
using Idemia.MicrochipMachine.BackEnd;
using Idemia.MicrochipMachine.NotificationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Idemia.MicrochipMachine
{
    class Program: INotificationServiceCallback
    {
        public static List<RequestStatus> Statuses = new List<RequestStatus>();
        private static Random _random = new Random();

        static void Main(string[] args)
        {
            /////////////////////////////////Set up Publish Events
            InstanceContext site = new InstanceContext(new Program());
            NotificationServiceClient client = new NotificationServiceClient(site);

            ////////////////////////////////End Setup

            BackendServiceClient backendClient = new BackendServiceClient();
            Statuses = backendClient.GetRequestStatuses().ToList();
            WriteConsole("Launching the Microship Machine.. Hold on");
            WriteConsole("Hi... I'm you Microship manufacturing machine.");
            WriteConsole("I can only process one request at a time. No multiThreading required here!");
            client.PublishMachineChange(0,0,0,"StartManufacturing");

            StartManufacturing(client);
            Console.ReadLine();
        }

        private static void StartManufacturing(NotificationServiceClient notificationClient)
        {
            BackendServiceClient client = new BackendServiceClient();
            WriteConsole("Start Manufactoring Triggered!");
            List<FactoryStatistic> stats = client.GetFactoryStats(null, null).ToList();
            WriteConsole("**************************Current Statistics***************");
            stats.ForEach(stat => WriteConsole(string.Format("{0}:{1}", stat.Status, stat.Count)));
            WriteConsole("*************************************************************");
            Request request = client.GetNextRequest();
            if (stats.First(s => s.Status.ToLower() == "inprogress").Count > 0)
            {
                notificationClient.PublishMachineChange(0,0,0,"Error-AlreadyInProgress");
                WriteConsole("There is an Item already in production");
                WriteConsole("Enter C  clear production or Q to exit:");
                string c = Console.ReadLine();
                if (c.ToLower() == "c" || c.ToLower() == "clear") client.ClearInProgress();
                else return;
            }
            if (stats.First(s => s.Status.ToLower() == "done").Count > 300)
            {
                notificationClient.PublishMachineChange(0,0,0,"DailyLimit");

                WriteConsole("Maximuim number of items to produce per day exceeded");
                return;
            }
            if (request != null)
            {
                WriteConsole("Will start processing Request Number: " + request.Id.ToString());
                RequestStatus currentStatus = Statuses.First(s => s.Id == request.StatusId);
                WriteConsole("Current Status of the request is " + currentStatus.Name);
                notificationClient.PublishMachineChange(request.Id.Value,request.StatusId.Value,0,"Manufacturing");

                TransitionRequest(request, currentStatus);
                StartManufacturing(notificationClient);
            }
            else
            {
                WriteConsole("No more requests!");
            }
        }

        public static void TransitionRequest(Request request, RequestStatus currentStatus)
        {
            BackendServiceClient client = new BackendServiceClient();
            if (currentStatus.NextStatusId.HasValue && currentStatus.NextStatusId.Value > 0)
            {
                RequestStatus nextStatus = Statuses.First(s => s.Id == currentStatus.NextStatusId.Value);

                if (currentStatus.Duration > 0)
                {
                    WriteConsole("I will take " + currentStatus.Duration.ToString() + " seconds to proceed to " + nextStatus.Name);
                    Thread.Sleep(currentStatus.Duration * 1000);
                }
                client.TransitionRequest(request.Id.ToString(), currentStatus.NextStatusId.ToString(), nextStatus.NotifyCustomer.ToString(), nextStatus.NotifyManager.ToString());
                TransitionRequest(request, nextStatus);
            }
            else
            {
                WriteConsole("Request " + request.Id.ToString() + " was completed successfully!!");
            }

        }
        public static void WriteConsole(string toWrite) 
        {
            Console.ForegroundColor = GetRandomConsoleColor();
            Console.WriteLine(toWrite);
        }
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }


        public void MachineChange(int requestId, int statusId, int progress, string state)
        {
           Console.WriteLine("MachineChnage(Request {0}, Status {1}, Progress {2}, State {3})", requestId, statusId, progress, state);
        }
    }
}
