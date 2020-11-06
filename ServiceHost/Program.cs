using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceEventOrganize;
using WcfServiceEventOrganize.Services;
using WcfServiceEventOrganize.Contracts;



namespace ServiceHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/Service1/");

            // Step 2: Create a ServiceHost instance.
            ServiceHost selfHost = new ServiceHost(typeof(Service1), baseAddress);
            ServiceHost selfHostAttendant = new ServiceHost(typeof(AttendantService), baseAddress);
            ServiceHost selfHostEvent = new ServiceHost(typeof(EventService), baseAddress);
            ServiceHost selfHostUserProfile = new ServiceHost(typeof(UserProfileService), baseAddress);

            try
            {
                // Step 3: Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(IService1), new WSHttpBinding(), "Service1");
               

                // Step 4: Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5: Start the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");

                // Close the ServiceHost to stop the service.
                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
