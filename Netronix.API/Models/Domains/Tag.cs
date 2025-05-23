namespace Netronix.API.Models.Domains
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } // name of the tag

        public List<ProductTags> ProductTags { get; set; } = new();
    }
}
