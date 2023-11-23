using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop6.DTO;
using PetShop6.Models;

namespace PetShop6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private DataContext _context;
        public ProductsController(DataContext _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("{ProductID}")]
        public async Task<IActionResult>GetProductById(int ProductID)
        {
            var product = await _context.Products.FindAsync(ProductID);
            if(product == null) 
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO requestProduct)
        {
            var product = new ProductModel()
            {
                Description = requestProduct.Description,
                Price = requestProduct.Price,
                StockQuantity = requestProduct.StockQuantity,
                ImageURL = requestProduct.ImageURL,
                CateryID = requestProduct.CateryID,
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int  ProductID, ProductDTO requestProduct)
        {
            var product = await _context.Products.FindAsync(ProductID);
            if (product == null) return NotFound("Product not found");
            product.ProductName = requestProduct.ProductName;
            product.Description = requestProduct.Description;
            product.Price = requestProduct.Price;
            product.StockQuantity = requestProduct.StockQuantity;
            product.ImageURL = requestProduct.ImageURL;
            product.CateryID = requestProduct.CateryID;

            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpDelete("{ProductID}")]
        public async Task<IActionResult> DeleteById(int ProductID)
        {
            var product = await _context.Products.FindAsync(ProductID);
            if (product == null) return NotFound("Product not found");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok("Product has been deleted!");
        }
    }
}
