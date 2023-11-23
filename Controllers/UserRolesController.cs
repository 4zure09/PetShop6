using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop6.DTO;
using PetShop6.Models;

namespace PetShop6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly DataContext _context;

        public UserRolesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserRoles()
        {
            var userRoles = await _context.UserRoles.ToListAsync();
            return Ok(userRoles);
        }

        [HttpPut("{UserRoleID}")]
        public async Task<IActionResult> UpdateUserRole(int UserRoleID, UserRoleDTO requestUserRole)
        {
            // Kiểm tra xem UserRole có tồn tại không
            var userRole = await _context.UserRoles.FindAsync(UserRoleID);
            if (userRole == null)
            {
                return NotFound("UserRole not found");
            }

            // Kiểm tra xem UserID và RoleID có tồn tại không
            var user = await _context.Users.FindAsync(requestUserRole.UserID);
            var role = await _context.Users.FindAsync(requestUserRole.RoleID);

            if (user == null || role == null)
            {
                return BadRequest("User or Role not found");
            }

            // Cập nhật UserRole
            userRole.UserID = requestUserRole.UserID;
            userRole.RoleID = requestUserRole.RoleID;

            await _context.SaveChangesAsync();

            return Ok(userRole);
           }
    }
}