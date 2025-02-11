using TokenBasedAuthenticationDemo.Domain.Interfaces;

namespace TokenBasedAuthenticationDemo.Application.Products
{
    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _productRepository;

        public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public List<Domain.Entities.Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}
