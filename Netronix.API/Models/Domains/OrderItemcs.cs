namespace Netronix.API.Models.Domains
{
    public class OrderItemcs
    {
        public Guid Id { get; set; }

        public string? ProductName { get; set; }    
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
