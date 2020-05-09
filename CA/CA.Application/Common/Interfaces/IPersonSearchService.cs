using CA.Domain;
using System;
using System.Linq;

namespace CA.Application.Common.Interfaces
{
    public interface IPersonSearchService
    {
        IPersonSearchService InitializeSet(IQueryable<Person> personQuery);

        IPersonSearchService SearchName(String nameOfStrategy, PersonName personName);

        IQueryable<Person> AsQueryable();
    }
}
