using System.ComponentModel.DataAnnotations;

namespace Assesment_API_TokaReda.DTOs.Auth
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
    }
}
