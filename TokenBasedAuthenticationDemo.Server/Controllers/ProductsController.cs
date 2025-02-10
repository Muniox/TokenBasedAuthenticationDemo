using Microsoft.AspNetCore.Mvc;
using TokenBasedAuthenticationDemo.Domain;

namespace TokenBasedAuthenticationDemo.Server.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        [HttpGet]
        public List<Product> GetAll()
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
