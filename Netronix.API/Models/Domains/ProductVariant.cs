namespace Netronix.API.Models.Domains
{
    public class ProductVariant
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public List<VariantOption>? Options { get; set; }
    }
}
