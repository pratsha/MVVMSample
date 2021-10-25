using MVVMSample.PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TestApiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ITestService
    {

        [OperationContract]
        Int64 SetMobileNumber(Int64 mobile);

        [OperationContract]
        Int64 GetMobileNumber();

        [OperationContract]
        Int32 SetId(Int32 Id);

        [OperationContract]
        Int32 GetId();

        [OperationContract]
        string SetName(string name);

        [OperationContract]
        string GetName();

        [OperationContract]
        Dictionary<string, List<string>> AddPatient();

        [OperationContract]
        List<string> Search(int id);

        [OperationContract]
        Dictionary<string, List<string>> PatientGrid();

        [OperationContract]
        Dictionary<string, List<string>> DeletePatient(int id);
    }
}
