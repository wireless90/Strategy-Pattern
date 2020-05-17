using CA.Domain;
using System;
using System.Linq.Expressions;

namespace CA.Infrastructure.Common.Interfaces
{
    public interface IPersonExpSearchStrategy<T>
    {
        Expression<Func<Person, bool>> Run(Expression<Func<Person, bool>> personExpression, T searchObject, bool isAndClause);
    }
}
