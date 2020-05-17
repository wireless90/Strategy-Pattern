using CA.Domain;
using CA.Infrastructure.Common.Interfaces;
using LinqKit;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;

using System.Linq.Expressions;
namespace CA.Infrastructure.Services.PersonSearch.Strategies
{
    public class PersonNamePermuteExpSearchStrategy : IPersonExpSearchStrategy<PersonName>
    {
        public Expression<Func<Person, bool>> Run(Expression<Func<Person, bool>> personExpression, PersonName searchObject, bool isAndClause)
        {
            if (String.IsNullOrEmpty(searchObject.Name))
                return personExpression;

            String[] nameTokens = searchObject.Name.Split(" ");
            var predicate = PredicateBuilder.New<PersonName>(true);

            foreach (var name in nameTokens)
            {
                string temp = name;
                predicate = predicate.And(p => p.Name.Contains(temp));
            }

            Expression<Func<PersonName, bool>> expressionPredicate = predicate;


            Expression<Func<Person, bool>> newExpression = (person) =>
                person.PersonNames.Any(expressionPredicate.Compile());

            if (personExpression == null)
                return newExpression;


            return isAndClause ? personExpression.And(newExpression) : personExpression.Or(newExpression);
        }
    }
}
