using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CA.Domain
{
    [Table("PersonIdentifications")]
    public class PersonIdentification
    {
        public int Id { get; set; }

        public String Identification { get; set; }

        public String Type { get; set; }

        public int PersonId { get; set; }
    }
}
