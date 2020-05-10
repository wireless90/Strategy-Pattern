using Autofac;
using Autofac.Extensions.DependencyInjection;
using CA.Application.Common.IOC;
using CA.Infrastructure.Common.IOC;
using CA.Persistence.Common.IOC;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CA.Web.Common.IOC
{
    public static class ContainerConfig
    {
        public static IServiceProvider Build(IServiceCollection services)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(services);

            containerBuilder.RegisterModule(new ApplicationModule())
                .RegisterModule(new InfrastructureModule())
                .RegisterModule(new PersistenceModule());
            
            IContainer container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
        }
    }
}
