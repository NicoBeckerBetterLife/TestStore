using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartHardwareShop.Contracts.Product;
using SmartHardwareShop.DBContexts;
using SmartHardwareShop.Models;

namespace SmartHardwareShop.Services.DataAccess
{
    public class ProductDataAccessService
    {
        private readonly SmartHardwareStoreDbContext _smartHardwareStoreDbContext;

        public ProductDataAccessService(SmartHardwareStoreDbContext smartHardwareStoreDbContext)
        {
            _smartHardwareStoreDbContext = smartHardwareStoreDbContext;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _smartHardwareStoreDbContext.Add(product);

            await _smartHardwareStoreDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var item =await LoadProduct(product.ProductId);
            item.Name = product.Name;
            item.Description = product.Description;
            item.ImageUrl = product.ImageUrl;
            item.Price = product.Price;
            item.Quantity = product.Quantity;
            item.IsDeleted = product.IsDeleted;
            if (product.IsDeleted && item.DeletedDateDate is null)
            {
                item.DeletedDateDate = DateTime.Now;
            }

            await _smartHardwareStoreDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> LoadProduct(int id)
        {
           return await _smartHardwareStoreDbContext.Set<Product>().FirstOrDefaultAsync(a => a.ProductId == id && !a.IsDeleted);
        }

        public async Task<ProductPagedListModel> SearchProduct(string search, int page, int pageSize)
        {
            var count = _smartHardwareStoreDbContext.Set<Product>().Count(a => a.Name.Contains(search) || a.Description.Contains(search));
            var items = await _smartHardwareStoreDbContext.Set<Product>().Where(a => !a.IsDeleted && (a.Name.Contains(search) || a.Description.Contains(search))).Skip((page-1)* pageSize).Take(pageSize).ToListAsync();
            return new ProductPagedListModel
            {
                Count = count,
                Products = items
            };
        }
    }
}