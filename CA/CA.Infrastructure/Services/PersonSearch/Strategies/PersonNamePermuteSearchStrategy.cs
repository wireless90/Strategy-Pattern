using CA.Domain;
using CA.Infrastructure.Common.Interfaces;
using System;
using System.Linq;

namespace CA.Infrastructure.Services.PersonSearch.Strategies
{
    public class PersonNamePermuteSearchStrategy : IPersonSearchStrategy<PersonName>
    {
        public IQueryable<Person> Run(IQueryable<Person> personQuery, PersonName searchObject)
        {
            return personQuery.Where(person =>
                String.IsNullOrEmpty(searchObject.Name) ||
                person.PersonNames.Any(personName =>
                    personName.Name.Contains(searchObject.Name)
                )
            );
        }
    }
}
