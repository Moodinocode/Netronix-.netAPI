using Netronix.API.Models.Domains;

namespace Netronix.API.Models.DTOs
{
    public class VariantsDto
    {
        public string? Name { get; set; }
        public List<VariantOptionsDto>? Options { get; set; }
    }
}
