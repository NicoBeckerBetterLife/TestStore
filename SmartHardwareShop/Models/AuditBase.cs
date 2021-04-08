using System;

namespace SmartHardwareShop.Models
{
    public class AuditBase
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? DeletedDateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}