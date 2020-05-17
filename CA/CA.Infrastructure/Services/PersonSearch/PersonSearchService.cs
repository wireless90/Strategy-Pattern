using Autofac.Features.Indexed;
using CA.Application.Common.Interfaces;
using CA.Domain;
using CA.Infrastructure.Common.Interfaces;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CA.Infrastructure.Services.PersonSearch
{
    public class PersonSearchService : IPersonSearchService
    {
        private readonly IPersonDbContext _personDbContext;
        private readonly IIndex<String, IPersonSearchStrategy<PersonName>> _personNameSearchStrategyFactory;
        private readonly IIndex<String, IPersonSearchStrategy<PersonIdentification>> _personIdentificationSearchStrategyFactory;

        private readonly IIndex<String, IPersonExpSearchStrategy<PersonName>> _personNameExpSearchStrategyFactory;
        private readonly IIndex<String, IPersonExpSearchStrategy<PersonIdentification>> _personIdentificationExpSearchStrategyFactory;

        private IQueryable<Person> _personQuery;
        private Expression<Func<Person, bool>> _personExpression;

        public PersonSearchService(
                IIndex<String, IPersonSearchStrategy<PersonName>> personNameSearchStrategyFactory,
                IIndex<String, IPersonSearchStrategy<PersonIdentification>> personIdentificationSearchStrategyFactory,
                IIndex<String, IPersonExpSearchStrategy<PersonName>> personNameExpSearchStrategyFactory,
                IIndex<String, IPersonExpSearchStrategy<PersonIdentification>> personIdentificationExpSearchStrategyFactory,
                IPersonDbContext personDbContext
            )
        {
            _personDbContext = personDbContext;
            _personNameSearchStrategyFactory = personNameSearchStrategyFactory;
            _personIdentificationSearchStrategyFactory = personIdentificationSearchStrategyFactory;
            _personNameExpSearchStrategyFactory = personNameExpSearchStrategyFactory;
            _personIdentificationExpSearchStrategyFactory = personIdentificationExpSearchStrategyFactory;
            _personQuery = _personDbContext.Persons;

            _personExpression = null;
        }

        public IQueryable<Person> AsQueryable()
        {
            return _personExpression == null ? 
                _personQuery :
                _personQuery

                .Include(x => x.PersonNames)
                .Include(x => x.PersonIdentifications).AsExpandable().Where(_personExpression);
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

        public IPersonSearchService SearchNameExp(string nameOfStrategy, PersonName personName, bool isAndClause = true)
        {
            IPersonExpSearchStrategy<PersonName> personExpSearchStrategy = _personNameExpSearchStrategyFactory[nameOfStrategy];
            _personExpression = personExpSearchStrategy.Run(_personExpression, personName, isAndClause);

            return this;
        }

        public IPersonSearchService SearchIdentificationExp(string nameOfStrategy, PersonIdentification personIdentification, bool isAndClause = true)
        {
            IPersonExpSearchStrategy<PersonIdentification> personExpSearchStrategy = _personIdentificationExpSearchStrategyFactory[nameOfStrategy];
            _personExpression = personExpSearchStrategy.Run(_personExpression, personIdentification, isAndClause);

            return this;
        }
    }
}
