namespace Netronix.API.Models.Domains
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? brand { get; set; } // brand name
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public List<string>? ImageUrls { get; set; } //images to be displayed for product

        public bool IsBestSeller { get; set; }
        public List<ProductVariant>? Variants { get; set; }
        public List<ProductTags>? ProductTags { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        //public List<InventoryItem> Inventory { get; set; } = new();


        public decimal GetPriceWithOptions(IEnumerable<VariantOption> selectedOptions)
        {
            if (selectedOptions == null)
                return BasePrice;

            var totalAdjustment = selectedOptions.Sum(o => o.PriceAdjustment);
            return BasePrice + totalAdjustment;
        }
    }


}
