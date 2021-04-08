using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace SmartHardwareShop.Contracts.Product
{
    public class CartItemsListModel
    {
        public List<CartItemModel> CartItems { get; set; } = new List<CartItemModel>();
        public decimal CartTotal => CartItems.Sum(x => x.Total);
    }

    public class CartItemModel : Models.CartItem
    {
        public decimal Total => (ItemAmount * Product.Price);
    }
}