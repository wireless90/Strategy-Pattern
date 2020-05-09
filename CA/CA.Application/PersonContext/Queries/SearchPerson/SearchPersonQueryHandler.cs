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
            IQueryable<Person> personsQuery = _personDbContext.Persons
                .Include(person => person.PersonIdentifications)
                .Where(person => 
                    String.IsNullOrEmpty(request.Identification) ||
                    String.IsNullOrEmpty(request.IdentificationType) ||
                    person.PersonIdentifications.Any(p => 
                        p.Identification.Equals(request.Identification) && p.Type.Equals(request.IdentificationType)
                    )
                );

            return await _personSearchService.InitializeSet(personsQuery)
                .SearchName("PersonNamePermutePlus", new PersonName() { Name = request.Name })
                .AsQueryable()
                .ToListAsync();
        }
    }
}
