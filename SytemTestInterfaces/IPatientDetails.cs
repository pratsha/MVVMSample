using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SytemTestInterfaces
{
    public interface IPatientDetails
    {
        long SetMobileNumber(long mobile);
        Dictionary<string, List<string>> AddPatient();
        int SetId(int Id);
        string SetName(string name);
        long GetMobileNumber();

        int GetId();
        string GetName();

        List<string> Search(int id);

        Dictionary<string, List<string>> PatientGrid();

        Dictionary<string, List<string>> DeletePatient(int id);
    }
}
