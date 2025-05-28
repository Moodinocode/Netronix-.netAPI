namespace Netronix.API.Models.Domains
{
    public class OrderItem
    {
        public Product product { get; set; }  
        public int Quantity { get; set; }
        public decimal TotalPrice => product.Price * Quantity;
    }
}
