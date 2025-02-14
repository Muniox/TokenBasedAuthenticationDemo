using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TokenBasedAuthenticationDemo.Application.Products;
using TokenBasedAuthenticationDemo.Domain.Entities;

namespace TokenBasedAuthenticationDemo.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }


        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            var products = _productsService.GetAllProducts();

            return products;
        }
    }
}
