using CA.Application.Common.Constants;
using CA.Application.Common.Interfaces;
using CA.Application.Common.Notifications.PersonSearch;
using CA.Domain;
using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
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
        private readonly IMediator _mediator;

        public SearchPersonQueryHandler(IPersonSearchService personSearchService, IMediator mediator)
        {
            _personSearchService = personSearchService;
            _mediator = mediator;
        }

        public async Task<List<Person>> Handle(SearchPersonQuery request, CancellationToken cancellationToken)
        {

            var persons = _personSearchService
                .SearchIdentificationExp(PersonSearchStrategyConstants.PersonIdentification.IdContainsIdTypeEquals, new PersonIdentification() { Identification = request.Identification, Type = request.IdentificationType }, false)
                .SearchNameExp(PersonSearchStrategyConstants.PersonName.PermutePlus, new PersonName() { Name = request.Name }, false)
                .AsQueryable()
                .ToList();

            await _mediator.Publish(new PersonSearchNotification());

            return persons;
        }
    }
}
