using CA.Domain;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.PersonContext.Queries.SearchPerson
{
    public class SearchPersonQueryHandler : IRequestHandler<SearchPersonQuery, List<Person>>
    {
        public SearchPersonQueryHandler()
        {

        }

        public Task<List<Person>> Handle(SearchPersonQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
