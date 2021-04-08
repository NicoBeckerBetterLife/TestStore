using SmartHardwareShop.Contracts.Product;
using SmartHardwareShop.Models;

namespace SmartHardwareShop.Extensions
{
    public static class ExtensionsMethods
    {
        public static CartItemModel ToModel(this CartItem item)
        {
            return new CartItemModel
            {
                IsDeleted = item.IsDeleted,
                IsAvailable = item.IsAvailable,
                ProductId = item.ProductId,
                DeletedDateDate = item.DeletedDateDate,
                Product = item.Product,
                UserId = item.UserId,
                CartItemId = item.CartItemId,
                CheckedOut = item.CheckedOut,
                CreatedDate = item.CreatedDate,
                ItemAmount = item.ItemAmount
            };
        }
    }
}