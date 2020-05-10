using Autofac;
using CA.Application.Common.Interfaces;
using CA.Domain;
using CA.Infrastructure.Common.Interfaces;
using CA.Infrastructure.Services.PersonSearch;
using CA.Infrastructure.Services.PersonSearch.Strategies;

namespace CA.Infrastructure.Common.IOC.Modules
{
    public class PersonSearchServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonNamePermuteSearchStrategy>()
                .Keyed<IPersonSearchStrategy<PersonName>>("PersonNamePermutePlus");
            
            builder.RegisterType<PersonIdentificationContainsAndTypeEqualsSearchStrategy>()
                .Keyed<IPersonSearchStrategy<PersonIdentification>>("PersonIdContainsAndTypeEquals");

            builder.RegisterType<PersonSearchService>()
                .As<IPersonSearchService>();

            base.Load(builder);
        }
    }
}
