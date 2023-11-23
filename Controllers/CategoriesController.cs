using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop6.DTO;
using PetShop6.Models;

namespace PetShop6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            return Ok(await _context.Cateries.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int CategoryID)
        {
            var category = await _context.Cateries.FindAsync(CategoryID);
            if (category == null)
            {
                return NotFound("Category not found");
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoriesDTO requestCategory)
        {
            if (ModelState.IsValid)
            {
                var category = new CategoriesModel
                {
                    CateryName = requestCategory.CateryName,

                };

                _context.Cateries.Add(category);
                await _context.SaveChangesAsync();

                return Ok(category);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int CategoryID, CategoriesDTO requestCategorie)
        {
            var category = await _context.Cateries.FindAsync(CategoryID);
            if (category == null)
            {
                return NotFound("Category not found");
            }

            category.CateryName = requestCategorie.CateryName;

            await _context.SaveChangesAsync();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int CategoryID)
        {
            var category = await _context.Cateries.FindAsync(CategoryID);
            if (category == null)
            {
                return NotFound("Category not found");
            }

            _context.Cateries.Remove(category);
            await _context.SaveChangesAsync();

            return Ok("Category has been deleted!");
        }
    }
}
