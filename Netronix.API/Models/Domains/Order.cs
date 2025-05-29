using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Netronix.API.Models.Domains
{
    public class Order
    {
        public Guid Id { get; set; }

        [Required]
        public int OrderNumber { get; set; }

        public List<OrderItem> items { get; set; } = new(); 

        // Consider making these calculated properties
        public decimal Subtotal => items.Sum(item => item.TotalPrice);
        public decimal DeliveryFee { get; set; }
        public decimal TotalAmount => Subtotal + DeliveryFee;

        public Guid AdressID { get; set; }
        public Adress? ShippingAddress { get; set; } 
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public string? PaymentMethod { get; set; }
        public bool IsPaid { get; set; } = false;

        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; } // Navigation property

        public bool IsGuestOrder { get; set; } = false;
        public OrderStatus Status { get; set; } = OrderStatus.OrderPlaced;
    }

    public enum OrderStatus
    {
        OrderPlaced,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
