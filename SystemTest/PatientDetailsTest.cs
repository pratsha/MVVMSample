using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SystemTestAdapter;
using SytemTestInterfaces;

namespace SystemTest
{
    [TestClass]
    public class PatientDetailsTest
    {
        static IPatientDetails pat;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            pat = new PatientDetails();
        }
        [TestMethod]
        public void Add_PatientDetails_VerifyAdded()
        {
            var mobile = pat.SetMobileNumber(7898745676);
            var name = pat.SetName("Test1");
            var id = pat.SetId(101);
            var dictPatient = pat.AddPatient();
            Thread.Sleep(5000);
            Assert.IsTrue(dictPatient.ContainsKey(id.ToString()));

        }

        [TestMethod]
        public void Search_PatientDetails_VerifyResults()
        {

            var id = 101;
            var lst = pat.Search(id);
            Console.WriteLine(lst.Count);
            foreach (var item in lst)
            {
                Thread.Sleep(2000);
                Assert.IsTrue(item.Length > 0);
                Console.WriteLine(item);
               
            }


        }

        [TestMethod]
        public void PatientDetails_VerifyGrid()
        {
            var mobile = pat.SetMobileNumber(9878659812);
            var name = pat.SetName("Test2");
            var id = pat.SetId(102);

            var dictPatients = pat.AddPatient();


            foreach (var item in dictPatients.Keys)
            {
                Thread.Sleep(2000);
                Assert.IsTrue(dictPatients[item][0].Length > 0);
                Assert.IsTrue(dictPatients[item][1].Length > 0);
                Console.WriteLine($"{item}|{dictPatients[item][0]}|{dictPatients[item][1]}");
                
            }

        }

        [TestMethod]
        public void PatientDetails_DeletePatient()
        {
            var id = 101;
            Thread.Sleep(2000);
            var dictPatients = pat.DeletePatient(id);
            Assert.IsFalse(dictPatients.ContainsKey(id.ToString()));
            

        }
    }
}
