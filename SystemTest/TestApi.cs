using TestApiService;

namespace SystemTest
{
    class TestApi
    {
        static TestClient client;

        static ITestService testService;
        internal static void Connect()
        {
            client = new TestClient();
            testService = client.CreateTestServiceProxy();
        }

        internal static ITestService GetTestService()
        {
            return testService;
        }
    }
}
