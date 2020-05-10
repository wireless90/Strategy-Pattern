using CA.Application.Common.Constants;
using CA.Application.Common.Interfaces;
using CA.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.PersonContext.Queries.SearchPerson
{
    public class SearchPersonQueryHandler : IRequestHandler<SearchPersonQuery, List<Person>>
    {
        private readonly IPersonDbContext _personDbContext;
        private readonly IPersonSearchService _personSearchService;

        public SearchPersonQueryHandler(IPersonDbContext personDbContext, IPersonSearchService personSearchService)
        {
            _personDbContext = personDbContext;
            _personSearchService = personSearchService;
        }

        public async Task<List<Person>> Handle(SearchPersonQuery request, CancellationToken cancellationToken)
        {
            return await _personSearchService
                .SearchIdentification(PersonSearchStrategyConstants.PersonIdentification.IdContainsIdTypeEquals, new PersonIdentification() { Identification = request.Identification, Type = request.IdentificationType})
                .SearchName(PersonSearchStrategyConstants.PersonName.PermutePlus, new PersonName() { Name = request.Name })
                .AsQueryable()
                .ToListAsync();
        }
    }
}
