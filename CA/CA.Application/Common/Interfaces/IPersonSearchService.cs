using CA.Domain;
using System;
using System.Linq;

namespace CA.Application.Common.Interfaces
{
    public interface IPersonSearchService
    {
        IPersonSearchService InitializeSet(IQueryable<Person> persons);

        IPersonSearchService SearchName(String nameOfStrategy, String name);

        IQueryable<Person> AsQueryable();
    }
}
