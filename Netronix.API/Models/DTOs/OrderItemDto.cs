using Netronix.API.Models.Domains;
using System.Text.Json.Serialization;

namespace Netronix.API.Models.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; } // Primary key for EF Core

        public Guid OrderId { get; set; } // Foreign key to Order.Id
        [JsonIgnore]
        public Order? Order { get; set; }

        // Product reference
        public Guid ProductId { get; set; }
        public Product? product { get; set; }

        // Snapshot data - preserve product info at time of order (for historical accuracy)
        public string? ProductName { get; set; }
        public decimal UnitPrice { get; set; }


        public int Quantity { get; set; }
        public List<SelectedVariantsDto>? SelectedOptions { get; set; } = new();

        // Calculated property to match your Order.Subtotal calculation
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
