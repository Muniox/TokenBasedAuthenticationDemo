using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace TokenBasedAuthenticationDemo.Infrastructure.Persistence
{
    public class DemoDbContext : IdentityDbContext
    {
        public DemoDbContext(DbContextOptions options) : base(options)
        {
            Products = Set<Domain.Entities.Product>();
        }

        public DbSet<Domain.Entities.Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasCharSet(CharSet.Utf8Mb4, DelegationModes.ApplyToColumns);
            modelBuilder.UseCollation("utf8mb4_unicode_ci", DelegationModes.ApplyToColumns);
        }
    }
}
