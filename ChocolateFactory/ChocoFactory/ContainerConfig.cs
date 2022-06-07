using Autofac;
using ChocoFactory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocoFactory.Domain

{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Scenario>().As<IScenario>();
            builder.RegisterType<Company>().As<ICompany>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<SupplierService>().As<ISupplierService>();



            return builder.Build();


        }
    }
}
