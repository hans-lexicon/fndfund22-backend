using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entitites;

namespace WebApi.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<ContactPersonEntity> ContactPersons { get; set; }
    }
}
