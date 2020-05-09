using CA.Domain;
using System.Linq;

namespace CA.Infrastructure.Common.Interfaces
{
    public interface IPersonSearchStrategy<T>
    {
        IQueryable<Person> Run(IQueryable<Person> personQuery, T searchObject);
    }
}
