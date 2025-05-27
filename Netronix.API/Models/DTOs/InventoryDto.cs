using Netronix.API.Models.Domains;

namespace Netronix.API.Models.DTOs
{
    public class InventoryDto
    {
        public int Quantity { get; set; }
        public List<string>? VariantOptions { get; set; }

    }
}
