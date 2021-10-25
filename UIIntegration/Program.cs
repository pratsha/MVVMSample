
using MVVMSample;
using MVVMSample.PresentationLayer.ViewModels;
using MVVMSample.PresentationLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIIntegration
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var viewModel = new PatientDetailViewModel();

            // Host Service
            var sericeHost = new TestApiService.HostService();
            var testService = new TestApiService.TestService(viewModel);
            sericeHost.Host(testService);

            var patientDetailView = new PatientDetailView();
            patientDetailView.DataContext = viewModel;

            System.Windows.Application app = new System.Windows.Application();
            app.Run(patientDetailView);

            Console.ReadKey();
        }
    }
}
