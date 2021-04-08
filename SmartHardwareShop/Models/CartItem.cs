using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHardwareShop.Models
{
    [Table("CartItem")]
    public class CartItem : AuditBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 CartItemId { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public int ItemAmount { get; set; }
        public bool CheckedOut { get; set; }
        public bool IsAvailable { get; set; }
        public string OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public virtual Product Product { get; set; }
    }
}