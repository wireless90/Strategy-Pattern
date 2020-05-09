using System.Collections.Generic;

namespace CA.Domain
{
    public class Person
    {
        public int Id { get; set; }

        List<PersonIdentification> PersonIdentifications { get; set; }

        List<PersonName> PersonNames { get; set; }
    }
}
