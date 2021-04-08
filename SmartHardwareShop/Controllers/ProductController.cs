using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHardwareShop.Auth;
using SmartHardwareShop.Models;
using SmartHardwareShop.Services;
using System.Threading.Tasks;

namespace SmartHardwareShop.Controllers
{
   [Authorize]
    [ApiController]
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
      
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var item = await _productService.LoadProduct(id);
            return Ok(item);
        }
       
        [HttpGet]
        [Route("ProductSearch")]
        public async Task<IActionResult> ProductSearch(string search, int page = 1, int pageSize = 20)
        {
            var item = await _productService.SearchProduct(search, page,pageSize);
            return Ok(item);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await _productService.AddProduct(product);
            return Ok(product);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            await _productService.UpdateProduct(product);
            return Ok(product);
        }
    }
}
