using Netronix.API.Models.Domains;

namespace Netronix.API.Models.DTOs
{
    public class AddProductRequestDto
    {
        public string? Name { get; set; }
        public string? brand { get; set; } 
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public List<string>? ImageUrls { get; set; } 

        public bool IsBestSeller { get; set; }
        public List<VariantsDto> Variants { get; set; } = new();
        public List<ProductTagDto> ProductTags { get; set; } = new();

        //public List<InventoryDto> Inventory { get; set; } = new();
    }
}
