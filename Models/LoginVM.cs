using System.ComponentModel.DataAnnotations;

namespace WineHouse.Models
{
    public class LoginVM
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
