namespace Netronix.API.Models.Domains
{
    public class Customer
    {
        public Guid Id { get; set; } // Primary key

        public string FirstName { get; set; } = string.Empty; // Required
        public string LastName { get; set; } = string.Empty; // Required
        public string Email { get; set; } = string.Empty; // Required, unique
        public string? PhoneNumber { get; set; } // Optional

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } // Nullable for optional updates

        // Navigation properties
        public List<Order>? Orders { get; set; }
    }
}
