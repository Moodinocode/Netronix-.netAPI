using Netronix.API.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace Netronix.API.Models.DTOs
{
    public class UpdateOrderRequestDto
    {


        public List<OrderItemDto> items { get; set; }
        public decimal Subtotal { get; set; }
        public decimal DeliveryFee { get; set; }


        public Adress? ShippingAddress { get; set; }

        public string? PaymentMethod { get; set; }
        public bool IsPaid { get; set; } = false;

        public Guid? CustomerId { get; set; }
        public bool IsGuestOrder { get; set; } = false;


        public enum OrderStatus
        {
            OrderPlaced,
            Processing,
            Shipped,
            Delivered,
            Cancelled
        }

        public OrderStatus Status { get; set; }
    }
}
