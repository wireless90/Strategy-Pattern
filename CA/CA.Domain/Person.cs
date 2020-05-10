using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CA.Domain
{
    [Table("Persons")]
    public class Person
    {
        public int Id { get; set; }

        public List<PersonIdentification> PersonIdentifications { get; set; }

        public List<PersonName> PersonNames { get; set; }
    }
}
