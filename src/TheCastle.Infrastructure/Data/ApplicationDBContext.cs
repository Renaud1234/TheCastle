using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheCastle.Kernel.Entities;

namespace TheCastle.Infrastructure.Data
{
    public class IGenericService : IdentityDbContext
    {
        public IGenericService(DbContextOptions<IGenericService> options)
            : base(options)
        {
        }

        public DbSet<Castle> Castles { get; set; }
        public DbSet<Army> Armies { get; set; }

        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
