using System.ComponentModel.DataAnnotations;

namespace PetShop6.DTO
{
    public class CategoriesDTO
    {
        [Required]
        public string CateryName { get; set; }
    }
}
