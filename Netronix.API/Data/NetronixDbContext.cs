using Microsoft.EntityFrameworkCore;
using Netronix.API.Models.Domains;

namespace Netronix.API.Data
{
    public class NetronixDbContext : DbContext
    {
        public NetronixDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<VariantOption> VariantOptions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Adress> Addresses { get; set; } // Keep your original class name
        //public DbSet<InventoryItem> InventoryItems { get; set; } // Pascal case
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; } // Pascal case
        public DbSet<ProductTags> ProductTags { get; set; } // Pascal case
        public DbSet<Customer> Customers { get; set; } // Added if you have Customer entity

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Order>()
                .Property(o => o.DeliveryFee)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

 

            modelBuilder.Entity<Order>()
                .HasMany(o => o.items) 
                .WithOne()
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

    
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Variants) 
                .WithOne(pv => pv.Product) 
                .HasForeignKey(pv => pv.ProductId) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductVariant>()
                .HasMany(p => p.Options)
                .WithOne(pv => pv.Variant)
                .HasForeignKey(pv => pv.VariantId)
                .OnDelete(DeleteBehavior.Cascade);


            //modelBuilder.Entity<Product>()
            //    .HasMany<InventoryItem>()
            //   .WithOne() 
            //    .HasForeignKey(ii => ii.ProductId) 
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductTags>()
                    .HasKey(pt => new { pt.ProductId, pt.TagId });

            modelBuilder.Entity<ProductTags>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductTags>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Customer>()
                .HasMany<Order>()
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders) 
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.items) 
                .HasForeignKey(oi => oi.OrderId);


         //   modelBuilder.Entity<InventoryItem>()
         //       .HasOne(ii => ii.Product)
         //       .WithMany(p => p.Inventory)
         //       .HasForeignKey(ii => ii.ProductId);

            modelBuilder.Entity<Order>()
                .Ignore(o => o.Subtotal)
                .Ignore(o => o.TotalAmount);

            modelBuilder.Entity<OrderItem>()
                .Ignore(oi => oi.TotalPrice);
        }
    }
}