using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace TestApiService
{
    public class HostService
    {
        private ServiceHost testApiServiceHost;

        private NetNamedPipeBinding namedPipeBinding;


        public void Host(ITestService testService)
        {
            try
            {
                const string EndPointAddress = "net.pipe://localhost/TestApiService";
                this.testApiServiceHost = new ServiceHost(testService);
                this.namedPipeBinding = new NetNamedPipeBinding()
                {
                    ReceiveTimeout = TimeSpan.FromHours(24 * 7)
                };

                this.testApiServiceHost.AddServiceEndpoint(typeof(ITestService), this.namedPipeBinding, EndPointAddress);
                
                this.testApiServiceHost.Open();
                Console.WriteLine("Test Service is open");
            }
            catch (ArgumentNullException e)
            {
                this.testApiServiceHost.Abort();
                Console.WriteLine("Exception caught while adding the endpoints: " + e.Message);
            }
            catch (AddressAlreadyInUseException e)
            {
                this.testApiServiceHost.Abort();
                Console.WriteLine("AddressAlreadyInUseException caught while adding the endpoints: " + e.Message);
            }
        }
    }
}
