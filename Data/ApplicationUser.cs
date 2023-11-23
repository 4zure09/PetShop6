using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace PetShop6.Data
{
    public class ApplicationUser :IdentityUser
    {
        public String FirstName { get; set; } = null!;
        public String LastName { get; set; } = null!;
    }
}
