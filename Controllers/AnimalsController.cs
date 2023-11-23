using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop6.DTO;
using PetShop6.Models;

namespace PetShop6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly DataContext _context;

        public AnimalsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimals()
        {
            return Ok(await _context.Animals.ToListAsync());
        }

        [HttpGet("{AnimalID}")]
        public async Task<IActionResult> GetAnimalById(int AnimalID)
        {
            var animal = await _context.Animals.FindAsync(AnimalID);
            if (animal == null)
            {
                return NotFound("Animal not found");
            }

            return Ok(animal);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnimal(AnimalDTO requestAnimal)
        {
            if (ModelState.IsValid)
            {
                var animal = new AnimalModel
                {
                    AnimalName = requestAnimal.AnimalName,
                    Description = requestAnimal.Description,
                    ImageURL = requestAnimal.ImageURL,
                };

                _context.Animals.Add(animal);
                await _context.SaveChangesAsync();

                return Ok(animal);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{AnimalID}")]
        public async Task<IActionResult> UpdateAnimal(int AnimalID, AnimalDTO requestAnimal)
        {
            var animal = await _context.Animals.FindAsync(AnimalID);
            if (animal == null)
            {
                return NotFound("Animal not found");
            }

            animal.AnimalName = requestAnimal.AnimalName;
            animal.Description = requestAnimal.Description;
            animal.ImageURL = requestAnimal.ImageURL;

            await _context.SaveChangesAsync();

            return Ok(animal);
        }

        [HttpDelete("{AnimalID}")]
        public async Task<IActionResult> DeleteAnimal(int AnimalID)
        {
            var animal = await _context.Animals.FindAsync(AnimalID);
            if (animal == null)
            {
                return NotFound("Animal not found");
            }

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();

            return Ok("Animal has been deleted!");
        }
    }
}
