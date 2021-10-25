using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TestApiService
{
    public class TestClient
    {
        private static ITestService testServiceProxy;
        
        private static ChannelFactory<ITestService> testServiceFactory;

        #region Private Members

        /// <summary>
        /// wcf service uri
        /// </summary>
        private string netNamedPipeBindingUri = "net.pipe://localhost/TestApiService";

        /// <summary>
        /// NetNamedPipe Binding
        /// </summary>
        private NetNamedPipeBinding netNamedPipeBinding;

        /// <summary>
        /// End point Address
        /// </summary>
        private EndpointAddress endpointAddress;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates instance of UxTestApiClient
        /// </summary>
        public TestClient()
        {
            this.netNamedPipeBinding = new NetNamedPipeBinding()
            {
                SendTimeout = TimeSpan.FromMinutes(5),
                ReceiveTimeout = TimeSpan.FromHours(24 * 7),
                MaxReceivedMessageSize = int.MaxValue
            };

            this.endpointAddress = new EndpointAddress(this.netNamedPipeBindingUri);
        }

        public ITestService CreateTestServiceProxy()
        {
            testServiceFactory = new ChannelFactory<ITestService>(new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/TestApiService"));
            testServiceProxy = testServiceFactory.CreateChannel();

            return testServiceProxy;
        }

        #endregion
    }
}
