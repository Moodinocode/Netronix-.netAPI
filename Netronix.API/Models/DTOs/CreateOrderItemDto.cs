using Netronix.API.Models.Domains;

namespace Netronix.API.Models.DTOs
{
    public class CreateOrderItemDto
    {
        public Guid productId { get; set; }
        public int Quantity { get; set; }
        public List<SelectedVariantsDto>? SelectedOptions { get; set; } = new();
    }
}
