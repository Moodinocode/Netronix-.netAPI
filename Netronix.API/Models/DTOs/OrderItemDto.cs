using Netronix.API.Models.Domains;

namespace Netronix.API.Models.DTOs
{
    public class OrderItemDto
    {
        public Guid productID { get; set; }
        public int Quantity { get; set; }
    }
}
