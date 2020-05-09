using CA.Domain;
using MediatR;
using System;
using System.Collections.Generic;

namespace CA.Application.PersonContext.Queries.SearchPerson
{
    /// <summary>
    ///     <Description>
    ///         This query is used to search a Person given:
    ///             1) Name
    ///             2) IdentificationType and Identification
    ///             3) Name and IdentificationType and Identification
    ///             
    ///         The Name search uses the PermutePlus Logic.
    ///         The IdentificationType uses the Equals Logic.
    ///         The Identification Uses the Contains Logic.
    ///     </Description>
    /// </summary>
    public class SearchPersonQuery : IRequest<List<Person>>
    {
        public String Name { get; set; }

        public String IdentificationType { get; set; }

        public String Identification { get; set; }
    }
}
