using System.Text.Json.Serialization;

namespace Netronix.API.Models.Domains
{
    public class VariantOption
    {
        public Guid Id { get; set; }
        
        public Guid VariantId { get; set; }
        [JsonIgnore]
        public ProductVariant? Variant { get; set; }

        public string? Value { get; set; } // name of the option if variantID -> color then option -> black or blue
        
        public int quantity { get; set; }
        public decimal PriceAdjustment { get; set; }

    }
}
