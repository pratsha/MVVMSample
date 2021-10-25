using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApiService;

namespace TestServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClient client = new TestClient();
            var testApp = client.CreateTestServiceProxy();

            testApp.SetId(102);
            testApp.SetName("Prateek");
            testApp.SetMobileNumber(56565733);
            testApp.AddPatient();
            testApp.SetId(103);
            testApp.SetName("Test");
            testApp.SetMobileNumber(8909867876556);
            foreach (var item in testApp.AddPatient())
            {

                Console.WriteLine("Added Item:" + item.Key);
            }
            foreach (var item in testApp.DeletePatient(102))
            {
                Console.WriteLine("Left After Delete: " + item.Key);
            }
            Console.ReadKey();
        }
    }
}
