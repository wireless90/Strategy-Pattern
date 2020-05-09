using CA.Domain;
using System;
using System.Linq;

namespace CA.Application.Common.Interfaces
{
    interface IPersonSearchService
    {
        IPersonSearchService InitializeSet(IQueryable<Person> persons);

        IPersonSearchService SearchName(String nameOfStrategy);

        IQueryable<Person> AsQueryable();
    }
}
