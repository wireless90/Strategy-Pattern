using CA.Domain;
using MediatR;
using System;
using System.Collections.Generic;

namespace CA.Application.PersonContext.Queries.SearchPerson
{
    public class SearchPersonQuery : IRequest<List<Person>>
    {
        public String Name { get; set; }

        public String IdentificationType { get; set; }

        public String Identification { get; set; }
    }
}
