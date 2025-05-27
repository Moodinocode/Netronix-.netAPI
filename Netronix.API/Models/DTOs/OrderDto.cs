using Netronix.API.Models.Domains;
using System.ComponentModel.DataAnnotations;

namespace Netronix.API.Models.DTOs
{
    public class OrderDto
    {
            public Guid Id { get; set; }
            [Required]
            public int OrderNumber { get; set; }

            public List<OrderItemcs> items { get; set; } = new();
            public decimal Subtotal { get; set; }
            public decimal DeliveryFee { get; set; }
            public decimal TotalAmount { get; set; } // calculated as Subtotal + DeliveryFee


            public Adress? ShippingAddress { get; set; }
            public DateTime OrderDate { get; set; } = DateTime.UtcNow;

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

            public OrderStatus Status { get; set; } = OrderStatus.OrderPlaced;



        }
    }



