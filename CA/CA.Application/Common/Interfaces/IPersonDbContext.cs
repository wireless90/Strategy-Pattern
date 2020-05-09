using CA.Domain;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Common.Interfaces
{
    public interface IPersonDbContext
    {
        DbSet<Person> Persons { get; set; }
    }
}
