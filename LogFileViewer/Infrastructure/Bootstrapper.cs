using LogFileViewer.Services;
using LogFileViewer.ViewModels;
using LogFileViewer.Views;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileViewer.Infrastructure
{
    public class Bootstrapper
    {
        public static void Initialize()
        {
            var kernel = CreateKernel();
            IoC.Initialize(kernel);
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);

            return kernel;
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAuthenticationService>().To<AuthenticationService>().InSingletonScope();
            kernel.Bind<ILogDataParser>().To<LogDataParser>().InSingletonScope();
            kernel.Bind<ICSVFileService>().To<CSVFileService>().InSingletonScope();
            kernel.Bind<INavigationService>().To<NavigationService>().InSingletonScope();
        }
    }
}
