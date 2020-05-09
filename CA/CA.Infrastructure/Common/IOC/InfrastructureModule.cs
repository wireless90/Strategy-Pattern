
using Autofac;
using CA.Infrastructure.Common.IOC.Modules;

namespace CA.Infrastructure.Common.IOC
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new PersonSearchStrategyModule());

            base.Load(builder);
        }
    }
}
