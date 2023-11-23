
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShop6.Models
{
    public class CategoriesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CateryID { get; set; }
        [Required]
        public string CateryName { get; set; }
    }
}
