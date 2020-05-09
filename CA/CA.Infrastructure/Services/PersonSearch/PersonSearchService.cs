using Autofac.Features.Indexed;
using CA.Application.Common.Interfaces;
using CA.Domain;
using CA.Infrastructure.Common.Interfaces;
using System;
using System.Linq;

namespace CA.Infrastructure.Services.PersonSearch
{
    public class PersonSearchService : IPersonSearchService
    {
        private readonly IPersonDbContext _personDbContext;
        private readonly IIndex<String, IPersonSearchStrategy<PersonName>> _personNameSearchStrategyFactory;

        private IQueryable<Person> _personQuery;

        public PersonSearchService(
                IIndex<String, IPersonSearchStrategy<PersonName>> personNameSearchStrategyFactory, 
                IPersonDbContext personDbContext
            )
        {
            _personDbContext = personDbContext;
            _personNameSearchStrategyFactory = personNameSearchStrategyFactory;

            _personQuery = Enumerable.Empty<Person>().AsQueryable();
        }

        public IQueryable<Person> AsQueryable()
        {
            return _personQuery;
        }

        public IPersonSearchService InitializeSet(IQueryable<Person> personQuery)
        {
            _personQuery = personQuery;

            return this;
        }

        public IPersonSearchService SearchName(string nameOfStrategy, PersonName personName)
        {
            IPersonSearchStrategy<PersonName> personSearchStrategy = _personNameSearchStrategyFactory[nameOfStrategy];

            _personQuery = personSearchStrategy.Run(_personQuery, personName);

            return this;
        }
    }
}
