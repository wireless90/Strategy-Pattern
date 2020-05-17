using CA.Application.Common.Constants;
using CA.Application.Common.Interfaces;
using CA.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Application.PersonContext.Queries.SearchPerson
{
    public class SearchPersonQueryHandler : IRequestHandler<SearchPersonQuery, List<Person>>
    {
        private readonly IPersonSearchService _personSearchService;

        public SearchPersonQueryHandler(IPersonSearchService personSearchService)
        {
            _personSearchService = personSearchService;
        }

        public Task<List<Person>> Handle(SearchPersonQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_personSearchService
                .SearchIdentificationExp(PersonSearchStrategyConstants.PersonIdentification.IdContainsIdTypeEquals, new PersonIdentification() { Identification = request.Identification, Type = request.IdentificationType }, false)
                .SearchNameExp(PersonSearchStrategyConstants.PersonName.PermutePlus, new PersonName() { Name = request.Name }, false)
                .AsQueryable()
                .ToList());
        }
    }
}
