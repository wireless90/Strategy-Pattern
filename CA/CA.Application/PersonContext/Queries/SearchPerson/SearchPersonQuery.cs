using CA.Domain;
using MediatR;
using System.Collections.Generic;

namespace CA.Application.PersonContext.Queries.SearchPerson
{
    public class SearchPersonQuery : IRequest<List<Person>>
    {
    }
}
