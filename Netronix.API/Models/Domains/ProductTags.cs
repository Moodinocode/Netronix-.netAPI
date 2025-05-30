using System.Text.Json.Serialization;

namespace Netronix.API.Models.Domains
{
    public class ProductTags
    {
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Product? Product { get; set; }

        public Guid TagId { get; set; }
        [JsonIgnore]
        public Tag? Tag { get; set; }
    }
}
