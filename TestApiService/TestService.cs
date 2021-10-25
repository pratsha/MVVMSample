using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MVVMSample.PresentationLayer.Models;
using MVVMSample.PresentationLayer.ViewModels;

namespace TestApiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.

    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any, InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
    public class TestService : ITestService
    {
        private readonly PatientDetailViewModel testViewModel;

        public TestService(PatientDetailViewModel testViewModel)
        {
            this.testViewModel = testViewModel;
        }

        public long SetMobileNumber(long mobile)
        {
            testViewModel.MobileNumber = mobile;
            return testViewModel.MobileNumber;
        }

        public Dictionary<string, List<string>> AddPatient()
        {
            testViewModel.AddPatientCmd.Execute(null);

            return PatientGrid();
        }

        public int SetId(int Id)
        {
            testViewModel.Id = Id;
            return testViewModel.Id;
        }

        public string SetName(string name)
        {
            testViewModel.Name = name;
            return testViewModel.Name;
        }

        public long GetMobileNumber()
        {
            return testViewModel.MobileNumber;
        }

        public int GetId()
        {
            return testViewModel.Id;
        }

        public string GetName()
        {
            return testViewModel.Name;
        }

        public List<string> Search(int id)
        {
            this.SetId(id);
            testViewModel.SearchPatientCmd.Execute(null);

            var lst = new List<string>();
            lst.Add(testViewModel.Id.ToString());
            lst.Add(testViewModel.Name.ToString());
            lst.Add(testViewModel.MobileNumber.ToString());

            return lst;
        }

        public Dictionary<string, List<string>> PatientGrid()
        {
            var patients= testViewModel.Patients;
            List<Patient> patientList = new List<Patient>();

            Dictionary<string, List<string>> keyValueListDict = new Dictionary<string, List<string>>();

            foreach (var item in patients)
            {
                List<string> details = new List<string>();
                details.Add(item.Name);
                details.Add(item.MobileNumber.ToString());
                keyValueListDict.Add(item.Id.ToString(), details);
            }

            return keyValueListDict;
        }

        public Dictionary<string, List<string>> DeletePatient(int id)
        {
            this.SetId(id);
            testViewModel.DeletePatientCmd.Execute(null);
            return PatientGrid();
        }
    }
}
