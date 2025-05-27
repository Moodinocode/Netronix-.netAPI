using Microsoft.EntityFrameworkCore;
using Netronix.API.Models.Domains;

namespace Netronix.API.Data
{
    public class NetronixDbContext: DbContext
    {
        public NetronixDbContext(DbContextOptions  options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<VariantOption> VariantOptions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Adress> adresses { get; set; }
        public DbSet<InventoryItem> inventoryItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItemcs> orderItems { get; set; }
        public DbSet<ProductTags> productTags { get; set; }


    }
}
