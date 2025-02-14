

using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TokenBasedAuthenticationDemo.Domain.Interfaces;
using TokenBasedAuthenticationDemo.Infrastructure.Persistence;
using TokenBasedAuthenticationDemo.Infrastructure.Repositories;

namespace TokenBasedAuthenticationDemo.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DemoDbContext>(options => options.UseMySql(
                configuration.GetConnectionString("AuthDemo"),
                new MariaDbServerVersion(new Version(10, 5, 0))
                ));


            services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<DemoDbContext>();

            // domyslnie token wygasa po 1h, zmieniamy na 1min
            services.ConfigureAll<BearerTokenOptions>(option => option.BearerTokenExpiration = TimeSpan.FromMinutes(1));

            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
