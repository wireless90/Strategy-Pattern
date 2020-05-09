using CA.Application.Common.Interfaces;
using CA.Domain;
using System.Linq;

namespace CA.Infrastructure.Services.PersonSearch
{
    public class PersonSearchService : IPersonSearchService
    {
        public IQueryable<Person> AsQueryable()
        {
            throw new System.NotImplementedException();
        }

        public IPersonSearchService InitializeSet(IQueryable<Person> persons)
        {
            throw new System.NotImplementedException();
        }

        public IPersonSearchService SearchName(string nameOfStrategy, string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
