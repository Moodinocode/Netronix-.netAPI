using System.Text.Json.Serialization;

namespace Netronix.API.Models.Domains
{
    public class SelectedVariantOption
    {
        public Guid Id { get; set; }

        // Foreign key to OrderItem
        public Guid OrderItemId { get; set; }
        [JsonIgnore]
        public OrderItem? OrderItem { get; set; }

        // Foreign key to ProductVariant
        public Guid ProductVariantId { get; set; }
        [JsonIgnore]
        public ProductVariant? ProductVariant { get; set; }
        public Guid VariantOptionID { get; set; }
        [JsonIgnore]
        public VariantOption? VariantOption { get; set; }


        // Snapshot data
        public string? VariantName { get; set; }     // e.g., "Size"
        public string? OptionValue { get; set; }     // e.g., "Large"
        public decimal PriceAdjustment { get; set; } // Keep historical price info
    }
}
