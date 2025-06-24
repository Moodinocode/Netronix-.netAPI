using System.ComponentModel.DataAnnotations;

namespace Netronix.API.Models.DTOs
{
    public class loginDtocs
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
