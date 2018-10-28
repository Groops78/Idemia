using Idemia.SampleSuscriber.NotificationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Idemia.SampleSuscriber
{
    class Program : INotificationServiceCallback
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Hi from Suscriber Console!");
            InstanceContext site = new InstanceContext(null, new Program());

            NotificationServiceClient client = new NotificationServiceClient(site);

            //create a unique callback address so multiple clients can run on one machine
            WSDualHttpBinding binding = (WSDualHttpBinding)client.Endpoint.Binding;
            string clientcallbackaddress = binding.ClientBaseAddress.AbsoluteUri;
            clientcallbackaddress += Guid.NewGuid().ToString();
            binding.ClientBaseAddress = new Uri(clientcallbackaddress);

            //Subscribe.
            Console.WriteLine("Subscribing");
            client.Subscribe();

            Console.WriteLine();
            Console.WriteLine("Press ENTER to unsubscribe and shut down client");
            Console.ReadLine();

            Console.WriteLine("Unsubscribing");
            client.Unsubscribe();

            //Closing the client gracefully closes the connection and cleans up resources
            client.Close();
        }


        public void MachineChange(int requestId, int statusId, int progress, string state)
        {
            Console.WriteLine("MachineChnage(Request {0}, Status {1}, Progress {2}, State {3})", requestId, statusId, progress, state);
        }



    }
}
