namespace Netronix.API.Models.Domains
{
    public class InventoryItem
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; } 
        public Product? Product { get; set; }
        public List<VariantOption>? inventoryItemVariantOptions { get; set; }

        public int Quantity { get; set; }
    }
}
