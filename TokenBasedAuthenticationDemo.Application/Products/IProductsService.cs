using TokenBasedAuthenticationDemo.Domain.Entities;

namespace TokenBasedAuthenticationDemo.Application.Products
{
    public interface IProductsService
    {
        List<Product> GetAllProducts();
    }
}