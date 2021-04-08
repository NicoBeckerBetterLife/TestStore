using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartHardwareShop.Contracts.Product;
using SmartHardwareShop.DBContexts;
using SmartHardwareShop.Extensions;
using SmartHardwareShop.Models;
using SmartHardwareShop.Services.DataAccess;

namespace SmartHardwareShop.Services
{
    public class CartService
    {
        private readonly CartItemDataAccessService _cartItemDataAccessService;
        private readonly ProductDataAccessService _productDataAccessService;

        public CartService(CartItemDataAccessService cartItemDataAccessService, ProductDataAccessService productDataAccessService)
        {
            _cartItemDataAccessService = cartItemDataAccessService;
            _productDataAccessService = productDataAccessService;
        }

        public async Task<CartItem> AddCartItem(int productId, int amount,string userName)
        {
            var user =await _cartItemDataAccessService.GetUserByName(userName);
            var product = await _productDataAccessService.LoadProduct(productId);

            var amountToAdd = amount < product.Quantity ? amount : product.Quantity;

            var existing = await _cartItemDataAccessService.GetCustomerCartItemsByProductId(userName,productId);
            if (existing != null)
            {
                existing.ItemAmount += amountToAdd;
                await _cartItemDataAccessService.SaveChanges();
                return existing;
            }

            var item = new CartItem
            {
                ItemAmount = amountToAdd,
                ProductId = productId,
                UserId = user.Id,
                IsAvailable = product.Quantity > 0
            };

            return await _cartItemDataAccessService.AddCartItem(item);
        }

        public async Task<CartItemsListModel> CheckOutCartItems(string userName)
        {
            var user = await _cartItemDataAccessService.GetUserByName(userName);
            var items = await _cartItemDataAccessService.GetCustomerCartItems(userName);
            var orderId = Guid.NewGuid().ToString();
            var orderDate = DateTime.Now;

            foreach (var item in items)
            {
                if (item.Product.Quantity >= item.ItemAmount)
                {
                    item.CheckedOut = true;
                    item.Product.Quantity = item.Product.Quantity - item.ItemAmount;
                    item.OrderDate = orderDate;
                    item.OrderId = orderId;
                }
            }

            await _cartItemDataAccessService.SaveChanges();


            return new CartItemsListModel
            {
                CartItems = items.Select(x => x.ToModel()).ToList()
            };
        }


        public async Task<CartItem> UpdateCartItem(CartItem cartItem)
        {
            return await _cartItemDataAccessService.UpdateCartItem(cartItem);
        }

        public async Task<CartItem> LoadCartItem(int id)
        {
            return await _cartItemDataAccessService.LoadCartItem(id);
        }

        public async Task<CartItemsListModel> GetCustomerCartItems(string userName)
        {
            var items = await _cartItemDataAccessService.GetCustomerCartItems(userName);
            return new CartItemsListModel
            {
                CartItems = items.Select(x => x.ToModel()).ToList()
            };
        }
    }
}