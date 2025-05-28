using Netronix.API.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace Netronix.API.Models.DTOs
{
    public class CreateOrderDto
    {
        public List<OrderItemDto> items { get; set; }
        public decimal DeliveryFee { get; set; }


        public AdressDto ShippingAddress { get; set; }

        public string PaymentMethod { get; set; }
        public bool IsPaid { get; set; } = false;



    }
}
