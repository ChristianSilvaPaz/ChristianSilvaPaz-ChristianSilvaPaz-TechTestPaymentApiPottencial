using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Services;

namespace Sales.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SellerController : Controller
    {
        private readonly SellerService _sellerService;

        public SellerController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet]
        public IActionResult GetSeller()
        {
            return Ok(_sellerService.GetSellers());
        }
    }
}
