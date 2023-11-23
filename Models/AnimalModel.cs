using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetShop6.Models
{
    public class AnimalModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalID { get; set; }
        [Required]
        public string AnimalName { get; set; }
        public string Description { get; set; }
        public string? ImageURL { get; set; }
    }
}
