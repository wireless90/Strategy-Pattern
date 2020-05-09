using Autofac;
using CA.Domain;
using CA.Infrastructure.Common.Interfaces;
using CA.Infrastructure.Services.PersonSearch.Strategies;

namespace CA.Infrastructure.Common.IOC.Modules
{
    public class PersonSearchStrategyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonNamePermuteSearchStrategy>()
                .Keyed<IPersonSearchStrategy<PersonName>>("PersonNamePermutePlus");

            base.Load(builder);
        }
    }
}
