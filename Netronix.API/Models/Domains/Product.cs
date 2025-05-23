namespace Netronix.API.Models.Domains
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? brand { get; set; } // brand name
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public List<string>? ImageUrls { get; set; } //images to be displayed for product

        public bool IsBestSeller { get; set; }
        public List<ProductVariant> Variants { get; set; } = new();
        public List<ProductTags> ProductTags { get; set; } = new();
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public List<InventoryItem> Inventory { get; set; } = new();

    }


}
