using System.Collections.Generic;
using System.Threading.Tasks;
using SmartHardwareShop.Contracts.Product;
using SmartHardwareShop.DBContexts;
using SmartHardwareShop.Models;
using SmartHardwareShop.Services.DataAccess;

namespace SmartHardwareShop.Services
{
    public class ProductService
    {
        private readonly ProductDataAccessService _productDataAccessService;

        public ProductService(ProductDataAccessService productDataAccessService)
        {
            _productDataAccessService = productDataAccessService;
        }

        public async Task<Product> AddProduct(Product product)
        {
            return await _productDataAccessService.AddProduct(product);
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            return await _productDataAccessService.UpdateProduct(product);
        }

        public async Task<Product> LoadProduct(int id)
        {
            return await _productDataAccessService.LoadProduct(id);
        }

        public async Task<ProductPagedListModel> SearchProduct(string search, int page, int pageSize)
        {
            return await _productDataAccessService.SearchProduct(search,page,pageSize);
        }
    }
}