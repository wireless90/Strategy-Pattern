using System.Collections.Generic;

namespace CA.Domain
{
    public class Person
    {
        public int Id { get; set; }

        public List<PersonIdentification> PersonIdentifications { get; set; }

        public List<PersonName> PersonNames { get; set; }
    }
}
