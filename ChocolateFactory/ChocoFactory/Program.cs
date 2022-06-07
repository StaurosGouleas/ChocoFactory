using Autofac;
using Newtonsoft.Json;
using ChocoFactory.Domain;
using ChocoFactory.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                IScenario scenario = scope.Resolve<IScenario>();
                scenario.Start();
            }

            

        }
    }
}
