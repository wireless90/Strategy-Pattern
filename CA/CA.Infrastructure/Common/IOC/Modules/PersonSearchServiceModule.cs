using Autofac;
using CA.Application.Common.Constants;
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
                .Keyed<IPersonSearchStrategy<PersonName>>(PersonSearchStrategyConstants.PersonName.PermutePlus);
            
            builder.RegisterType<PersonIdentificationContainsAndTypeEqualsSearchStrategy>()
                .Keyed<IPersonSearchStrategy<PersonIdentification>>(PersonSearchStrategyConstants.PersonIdentification.IdContainsIdTypeEquals);

            builder.RegisterType<PersonNamePermuteExpSearchStrategy>()
                .Keyed<IPersonExpSearchStrategy<PersonName>>(PersonSearchStrategyConstants.PersonName.PermutePlus);

            builder.RegisterType<PersonIdentificationContainsAndTypeEqualsExpSearchStrategy>()
                .Keyed<IPersonExpSearchStrategy<PersonIdentification>>(PersonSearchStrategyConstants.PersonIdentification.IdContainsIdTypeEquals);

            builder.RegisterType<PersonSearchService>()
                .As<IPersonSearchService>();

            base.Load(builder);
        }
    }
}
