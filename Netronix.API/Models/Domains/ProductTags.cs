namespace Netronix.API.Models.Domains
{
    public class ProductTags
    {
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public Guid TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
