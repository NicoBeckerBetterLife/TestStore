using System.Collections.Generic;

namespace SmartHardwareShop.Contracts.Product
{
    public class ProductPagedListModel
    {
        public List<Models.Product> Products { get; set; }
        public int Count { get; set; }
    }
}