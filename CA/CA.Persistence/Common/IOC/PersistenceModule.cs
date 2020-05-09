using Autofac;
using CA.Persistence.Common.IOC.Modules;

namespace CA.Persistence.Common.IOC
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DbContextModule());

            base.Load(builder);
        }
    }
}
