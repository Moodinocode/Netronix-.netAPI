using Netronix.API.Models.Domains;
using System.Text.Json.Serialization;

namespace Netronix.API.Models.DTOs
{
    public class SelectedVariantsDto
    {
        public Guid ProductVariantId { get; set; }     // e.g., ID - > "Size"
        public Guid VariantOptionID { get; set; }     // e.g., ID -> "Large
    }
}
