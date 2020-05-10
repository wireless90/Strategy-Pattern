using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CA.Domain
{
    [Table("PersonNames")]
    public class PersonName
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public int PersonId { get; set; }
    }
}
