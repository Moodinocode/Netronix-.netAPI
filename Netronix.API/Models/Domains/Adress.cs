namespace Netronix.API.Models.Domains
{
    public class Adress
    {
        public Guid Id { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string? ZipCode { get; set; }
        public required string Country { get; set; }
    }
}
