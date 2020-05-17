using CA.Domain;
using CA.Infrastructure.Common.Interfaces;
using LinqKit;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CA.Infrastructure.Services.PersonSearch.Strategies
{
    public class PersonIdentificationContainsAndTypeEqualsExpSearchStrategy : IPersonExpSearchStrategy<PersonIdentification>
    {
        public Expression<Func<Person, bool>> Run(Expression<Func<Person, bool>> personExpression, PersonIdentification searchObject, bool isAndClause)
        {
            if (String.IsNullOrEmpty(searchObject.Identification) || String.IsNullOrEmpty(searchObject.Type))
                return personExpression;

            Expression<Func<Person, bool>> newExpression = (person) =>
                person.PersonIdentifications.Any(i => i.Identification.Contains(searchObject.Identification) && i.Type == searchObject.Type);

            if (personExpression == null)
                return newExpression;


            return isAndClause ? personExpression.And(newExpression) : personExpression.Or(newExpression);
        }
    }
}
