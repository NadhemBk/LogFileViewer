using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFileViewer.Infrastructure
{
    public class IoC
    {
        public static IKernel Kernel { get; private set; }

        public static void Initialize(IKernel kernel) => Kernel = kernel;

        public static void Inject(object instance) => Kernel.Inject(instance);

    }
}
