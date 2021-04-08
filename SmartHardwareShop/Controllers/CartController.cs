using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SmartHardwareShop.Services;

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

        [AllowAnonymous]
        [HttpGet]
        [Route("GetBasket")]
        public async Task<IActionResult> GetBasket(string userName = null)
        {
            if (string.IsNullOrEmpty(userName))
                userName = User.Identity.Name;
            var item = await _cartService.GetCustomerCartItems(userName);
            return Ok(item);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("AddItemToCart")]
        public async Task<IActionResult> AddItemToCart(int productId, int amount, string userName = null)
        {
            if (string.IsNullOrEmpty(userName))
                userName = User.Identity.Name;
            var item = await _cartService.AddCartItem(productId, amount, userName);
            return Ok(item);
        }


        [AllowAnonymous]
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
