using Netronix.API.Models.Domains;

namespace Netronix.API.Models.DTOs
{
    public class VariantsDto
    {
        public string? Name { get; set; }
        public List<string>? Options { get; set; }
    }
}
