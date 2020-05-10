using Autofac.Features.Indexed;
using CA.Application.Common.Interfaces;
using CA.Domain;
using CA.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CA.Infrastructure.Services.PersonSearch
{
    public class PersonSearchService : IPersonSearchService
    {
        private readonly IPersonDbContext _personDbContext;
        private readonly IIndex<String, IPersonSearchStrategy<PersonName>> _personNameSearchStrategyFactory;
        private readonly IIndex<String, IPersonSearchStrategy<PersonIdentification>> _personIdentificationSearchStrategyFactory;

        private IQueryable<Person> _personQuery;

        public PersonSearchService(
                IIndex<String, IPersonSearchStrategy<PersonName>> personNameSearchStrategyFactory,
                IIndex<String, IPersonSearchStrategy<PersonIdentification>> personIdentificationSearchStrategyFactory,
                IPersonDbContext personDbContext
            )
        {
            _personDbContext = personDbContext;
            _personNameSearchStrategyFactory = personNameSearchStrategyFactory;
            _personIdentificationSearchStrategyFactory = personIdentificationSearchStrategyFactory;

            _personQuery = _personDbContext.Persons;
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

        public IPersonSearchService SearchName(string nameOfStrategy, PersonName personName, bool isEagerLoaded=true)
        {
            if(isEagerLoaded)
            {
                _personQuery = _personQuery.Include(person => person.PersonNames);
            }

            IPersonSearchStrategy<PersonName> personSearchStrategy = _personNameSearchStrategyFactory[nameOfStrategy];

            _personQuery = personSearchStrategy.Run(_personQuery, personName);

            return this;
        }

        public IPersonSearchService SearchIdentification(String nameOfStrategy, PersonIdentification personIdentification, bool isEagerLoaded = true)
        {
            if(isEagerLoaded)
            {
                _personQuery = _personQuery.Include(person => person.PersonIdentifications);
            }

            IPersonSearchStrategy<PersonIdentification> personSearchStrategy = _personIdentificationSearchStrategyFactory[nameOfStrategy];

            _personQuery = personSearchStrategy.Run(_personQuery, personIdentification);

            return this;
        }
    }
}
