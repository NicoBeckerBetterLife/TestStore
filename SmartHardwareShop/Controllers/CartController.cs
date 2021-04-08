using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHardwareShop.Services;
using System.Threading.Tasks;

namespace SmartHardwareShop.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        [Route("GetBasket")]
        public async Task<IActionResult> GetBasket(string userName = null)
        {
            if (string.IsNullOrEmpty(userName))
                userName = User.Identity.Name;
            var item = await _cartService.GetCustomerCartItems(userName);
            return Ok(item);
        }

        [HttpGet]
        [Route("AddItemToCart")]
        public async Task<IActionResult> AddItemToCart(int productId, int amount, string userName = null)
        {
            if (string.IsNullOrEmpty(userName))
                userName = User.Identity.Name;
            var item = await _cartService.AddCartItem(productId, amount, userName);
            return Ok(item);
        }


        [HttpGet]
        [Route("CheckoutCart")]
        public async Task<IActionResult> CheckoutCart(string userName = null)
        {
            if (string.IsNullOrEmpty(userName))
                userName = User.Identity.Name;
            var item = await _cartService.CheckOutCartItems(userName);
            return Ok(item);
        }

    }
}
