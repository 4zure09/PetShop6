using System.ComponentModel.DataAnnotations;

namespace PetShop6.Models
{
    public class SignUpModel
    {
        [Required]
        public String FirstName { get; set; } = null!;
        [Required]
        public String LastName { get; set; } = null!;
        [Required, EmailAddress]
        public String Email { get; set; } = null!;
        [Required]
        public String Password { get; set; } = null!;
        [Required]
        public String ConfirmPassword { get; set; } = null!;
    }
}
