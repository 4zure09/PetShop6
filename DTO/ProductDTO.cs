using System.ComponentModel.DataAnnotations;

namespace PetShop6.DTO
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        public string? ImageURL { get; set; }
        public int? CateryID { get; set; }
    }
}
