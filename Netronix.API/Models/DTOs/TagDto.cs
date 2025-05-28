using Netronix.API.Models.Domains;

namespace Netronix.API.Models.DTOs
{
    public class TagDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } // name of the tag

        public List<ProductTags> ProductTags { get; set; }
    }
}
