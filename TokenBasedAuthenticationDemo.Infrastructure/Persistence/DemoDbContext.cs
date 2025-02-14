using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using TokenBasedAuthenticationDemo.Domain.Entities;

namespace TokenBasedAuthenticationDemo.Infrastructure.Persistence
{
    public class DemoDbContext(DbContextOptions options) : IdentityDbContext<IdentityUser>(options)
    {

        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasCharSet(CharSet.Utf8Mb4, DelegationModes.ApplyToColumns);
            modelBuilder.UseCollation("utf8mb4_unicode_ci", DelegationModes.ApplyToColumns);
        }
    }
}

//namespace TokenBasedAuthenticationDemo.Infrastructure.Persistence
//{
//    public class DemoDbContext : IdentityDbContext
//    {
//        public DemoDbContext(DbContextOptions options) : base(options)
//        {
//            Products = Set<Product>();
//        }

//        public DbSet<Product> Products { get; set; }


//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            base.OnModelCreating(modelBuilder);

//            modelBuilder.HasCharSet(CharSet.Utf8Mb4, DelegationModes.ApplyToColumns);
//            modelBuilder.UseCollation("utf8mb4_unicode_ci", DelegationModes.ApplyToColumns);
//        }
//    }
//}
