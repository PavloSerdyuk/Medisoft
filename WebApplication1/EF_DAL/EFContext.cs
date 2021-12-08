using EF_DAL.Entities;
using EF_DAL.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace EF_DAL
{
    public class EFContext : DbContext
    {
        public DbSet<Person> Personnel { get; set; }

        public EFContext()
        {

        }

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
