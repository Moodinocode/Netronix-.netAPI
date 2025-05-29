namespace Netronix.API.Models.Domains
{
    public class OrderItem
    {
        public int Id { get; set; } // Primary key for EF Core

        public Guid OrderId { get; set; } // Foreign key to Order.Id
        public Order? Order { get; set; }

        // Product reference
        public Guid ProductId { get; set; }
        public Product? product { get; set; }

        // Snapshot data - preserve product info at time of order (for historical accuracy)
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string? ProductSku { get; set; }

        public int Quantity { get; set; }

        // Calculated property to match your Order.Subtotal calculation
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
