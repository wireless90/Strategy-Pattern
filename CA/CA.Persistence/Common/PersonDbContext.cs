using CA.Application.Common.Interfaces;
using CA.Domain;
using Microsoft.EntityFrameworkCore;

namespace CA.Persistence.Common
{
    public class PersonDbContext : DbContext, IPersonDbContext
    {
        public PersonDbContext()
        {

        }

        public DbSet<Person> Persons { get; set; }
    }
}
