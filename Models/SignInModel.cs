using System.ComponentModel.DataAnnotations;

namespace PetShop6.Models
{
    public class SignInModel
    {
        [Required, EmailAddress]
        public String Email { get; set; } = null!;
        [Required]
        public String Password { get; set; } = null!;
    }
}
