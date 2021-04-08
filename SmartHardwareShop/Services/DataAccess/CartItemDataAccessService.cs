using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using SmartHardwareShop.Contracts.Product;
using SmartHardwareShop.DBContexts;
using SmartHardwareShop.Extensions;
using SmartHardwareShop.Models;
using SmartHardwareShop.Models.Auth;

namespace SmartHardwareShop.Services.DataAccess
{
    public class CartItemDataAccessService
    {
        private readonly SmartHardwareStoreDbContext _smartHardwareStoreDbContext;

        public CartItemDataAccessService(SmartHardwareStoreDbContext smartHardwareStoreDbContext)
        {
            _smartHardwareStoreDbContext = smartHardwareStoreDbContext;
        }

        public async Task SaveChanges()
        {
            await _smartHardwareStoreDbContext.SaveChangesAsync();
        }

        public async Task<CartItem> AddCartItem(CartItem cartItem)
        {
            _smartHardwareStoreDbContext.Add(cartItem);

            await SaveChanges();

            return cartItem;
        }

        public async Task<CartItem> UpdateCartItem(CartItem cartItem)
        {
            var item = await LoadCartItem(cartItem.CartItemId);

            item.IsDeleted = cartItem.IsDeleted;
            if (cartItem.IsDeleted && item.DeletedDateDate is null)
            {
                item.DeletedDateDate = DateTime.Now;
            }

            await SaveChanges();

            return cartItem;
        }

        public async Task<CartItem> LoadCartItem(Int64 id)
        {
            return await _smartHardwareStoreDbContext.Set<CartItem>().FirstOrDefaultAsync(a => a.CartItemId == id);
        }

        public async Task<ApplicationUser> GetUserByName(string userName)
        {
            return await _smartHardwareStoreDbContext.Set<ApplicationUser>()
                .FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<List<CartItem>> GetCustomerCartItems(string userName)
        {
            var user = await GetUserByName(userName);
            var items = await _smartHardwareStoreDbContext.Set<CartItem>().Include(x => x.Product).Where(a => a.UserId == user.Id && !a.CheckedOut && !a.IsDeleted).ToListAsync();

            return items;
        }

        public async Task<CartItem> GetCustomerCartItemsByProductId(string userName, int productId)
        {
            var user = await GetUserByName(userName);

            var items = await _smartHardwareStoreDbContext.Set<CartItem>().Include(x => x.Product).FirstOrDefaultAsync(a => a.UserId == user.Id && a.ProductId == productId && !a.IsDeleted && !a.CheckedOut);
            return items;
        }
    }
}