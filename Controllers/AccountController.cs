using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop6.Models;
using PetShop6.Repositories;

namespace PetShop6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepo;

        public AccountController(IAccountRepository repo)
        {
            accountRepo = repo;
        }
        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await accountRepo.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult>SignIn(SignInModel signInModel)
        {
            var result = await accountRepo.SignInAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
