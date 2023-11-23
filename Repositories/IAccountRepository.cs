using Microsoft.AspNetCore.Identity;
using PetShop6.Models;

namespace PetShop6.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<String> SignInAsync(SignInModel model);
    }
}
