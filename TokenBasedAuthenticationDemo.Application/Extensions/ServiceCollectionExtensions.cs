using Microsoft.Extensions.DependencyInjection;
using TokenBasedAuthenticationDemo.Application.Products;

namespace TokenBasedAuthenticationDemo.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplictaion(this IServiceCollection services)
        {
            services.AddScoped<IProductsService, ProductsService>();
        }
    }
}
