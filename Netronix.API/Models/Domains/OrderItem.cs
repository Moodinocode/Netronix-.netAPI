using System.Text.Json.Serialization;

namespace Netronix.API.Models.Domains
{
    public class OrderItem
    {
        public Guid Id { get; set; } // Primary key for EF Core

        public Guid OrderId { get; set; } // Foreign key to Order.Id
        [JsonIgnore]
        public Order? Order { get; set; }

        // Product reference
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Product? product { get; set; }

        // Snapshot data - preserve product info at time of order (for historical accuracy)
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public List<SelectedVariantOption> SelectedOptions { get; set; } = new();

        // Calculated property to match your Order.Subtotal calculation
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
