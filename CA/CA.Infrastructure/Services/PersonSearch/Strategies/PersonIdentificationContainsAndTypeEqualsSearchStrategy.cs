using CA.Domain;
using CA.Infrastructure.Common.Interfaces;
using System;
using System.Linq;

namespace CA.Infrastructure.Services.PersonSearch.Strategies
{
    public class PersonIdentificationContainsAndTypeEqualsSearchStrategy : IPersonSearchStrategy<PersonIdentification>
    {
        public IQueryable<Person> Run(IQueryable<Person> personQuery, PersonIdentification searchObject)
        {
            return personQuery.Where(person =>
                String.IsNullOrEmpty(searchObject.Identification) ||
                String.IsNullOrEmpty(searchObject.Type) ||
                person.PersonIdentifications.Any(personIdentification =>
                    personIdentification.Identification.Contains(searchObject.Identification) &&
                    personIdentification.Type.Equals(searchObject.Type)
                )
            );
        }
    }
}
