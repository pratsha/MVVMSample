using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SytemTestInterfaces;

namespace SystemTestAdapter
{
    public class PatientDetails : IPatientDetails
    {
        public PatientDetails()
        {
            TestApi.Connect();
        }
        public Dictionary<string, List<string>> AddPatient()
        {
            return TestApi.GetTestService().AddPatient();
        }

        public Dictionary<string, List<string>> DeletePatient(int id)
        {
            return TestApi.GetTestService().DeletePatient(id);
        }

        public int GetId()
        {
            return TestApi.GetTestService().GetId();
        }

        public long GetMobileNumber()
        {
            return TestApi.GetTestService().GetMobileNumber();
        }

        public string GetName()
        {
            return TestApi.GetTestService().GetName();
        }

        public Dictionary<string, List<string>> PatientGrid()
        {
            return TestApi.GetTestService().PatientGrid();
        }
        
        public List<string> Search(int id)
        {
            return TestApi.GetTestService().Search(id);
        }

        public int SetId(int id)
        {
            return TestApi.GetTestService().SetId(id);
        }

        public long SetMobileNumber(long mobile)
        {
            return TestApi.GetTestService().SetMobileNumber(mobile);
        }

        public string SetName(string name)
        {
            return TestApi.GetTestService().SetName(name);
        }
    }
}
