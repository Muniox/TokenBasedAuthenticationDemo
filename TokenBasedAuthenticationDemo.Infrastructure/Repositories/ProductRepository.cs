using TokenBasedAuthenticationDemo.Domain.Entities;
using TokenBasedAuthenticationDemo.Domain.Interfaces;
using TokenBasedAuthenticationDemo.Infrastructure.Persistence;

namespace TokenBasedAuthenticationDemo.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        DemoDbContext _dbContext;

        public ProductRepository(DemoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> GetAllProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Product 1",
                    Description = "Description of Product 1",
                    Price = 100.99m,
                    Quantity = 10
                },
                new Product()
                {
                    Id = 2,
                    Name = "Product 2",
                    Description = "Description of Product 2",
                    Price = 200.99m,
                    Quantity = 20
                },
                new Product()
                {
                    Id = 3,
                    Name = "Product 3",
                    Description = "Description of Product 3",
                    Price = 300.99m,
                    Quantity = 30
                }
            };
        }
    }
}
