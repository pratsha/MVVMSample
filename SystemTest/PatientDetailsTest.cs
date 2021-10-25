using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestApiService;

namespace SystemTest
{
    [TestClass]
    public class PatientDetailsTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            TestApi.Connect();
        }
        [TestMethod]
        public void Add_PatientDetails_VerifyAdded()
        {
            var mobile = TestApi.GetTestService().SetMobileNumber(7898745676);
            var name = TestApi.GetTestService().SetName("Test1");
            var id = TestApi.GetTestService().SetId(101);
            var dictPatient = TestApi.GetTestService().AddPatient();
            Thread.Sleep(5000);
            Assert.IsTrue(dictPatient.ContainsKey(id.ToString()));

        }

        [TestMethod]
        public void Search_PatientDetails_VerifyResults()
        {

            var id = 101;
            var lst = TestApi.GetTestService().Search(id);
            Console.WriteLine(lst.Count);
            foreach (var item in lst)
            {
                Assert.IsTrue(item.Length > 0);
                Console.WriteLine(item);
                Thread.Sleep(2000);
            }


        }

        [TestMethod]
        public void PatientDetails_VerifyGrid()
        {
            var mobile = TestApi.GetTestService().SetMobileNumber(9878659812);
            var name = TestApi.GetTestService().SetName("Test2");
            var id = TestApi.GetTestService().SetId(102);

            var dictPatients = TestApi.GetTestService().AddPatient();


            foreach (var item in dictPatients.Keys)
            {
                Assert.IsTrue(dictPatients[item][0].Length > 0);
                Assert.IsTrue(dictPatients[item][1].Length > 0);
                Console.WriteLine($"{item}|{dictPatients[item][0]}|{dictPatients[item][1]}");
                Thread.Sleep(2000);
            }

        }

        [TestMethod]
        public void PatientDetails_DeletePatient()
        {
            var id = 101;

            var dictPatients = TestApi.GetTestService().DeletePatient(id);
            Assert.IsFalse(dictPatients.ContainsKey(id.ToString()));
            Thread.Sleep(2000);

        }
    }
}
