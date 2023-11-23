using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop6.DTO;
using PetShop6.Models;

namespace PetShop6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO requestUser)
        {
            if (ModelState.IsValid)
            {
                var user = new UserModel
                {
                    Username = requestUser.Username,
                    Password = requestUser.Password,
                    Email = requestUser.Email,
                    FullName = requestUser.FullName,
                    Address = requestUser.Address,
                    PhoneNumber = requestUser.PhoneNumber
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(user);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDTO requestUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            user.Username = requestUser.Username;
            user.Password = requestUser.Password;
            user.Email = requestUser.Email;
            user.FullName = requestUser.FullName;
            user.Address = requestUser.Address;
            user.PhoneNumber = requestUser.PhoneNumber;

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("User has been deleted!");
        }
    }
}
