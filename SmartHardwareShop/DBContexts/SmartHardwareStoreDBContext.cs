using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartHardwareShop.Models;
using SmartHardwareShop.Models.Auth;

namespace SmartHardwareShop.DBContexts
{
    public class SmartHardwareStoreDbContext : IdentityDbContext<IdentityUser>
    {
        //public DbSet<UserGroup> UserGroups { get; set; }
        //public DbSet<User> Users { get; set; }

        public SmartHardwareStoreDbContext(DbContextOptions<SmartHardwareStoreDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>();
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<CartItem>();
        }
    }
}