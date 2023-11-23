using System.ComponentModel.DataAnnotations;

namespace PetShop6.DTO
{
    public class AnimalDTO
    {
        [Required]
        public string AnimalName { get; set; }
        public string Description { get; set; }
        public string? ImageURL { get; set; }
    }
}
