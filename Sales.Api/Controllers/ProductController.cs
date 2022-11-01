using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Entities;
using Sales.Domain.Services;

namespace Sales.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProduct());
        }
    }
}
