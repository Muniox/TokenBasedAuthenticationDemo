using TokenBasedAuthenticationDemo.Domain.Entities;

namespace TokenBasedAuthenticationDemo.Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
    }
}
