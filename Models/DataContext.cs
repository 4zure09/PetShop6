using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetShop6.Controllers;
using PetShop6.Data;
using PetShop6.DTO;

namespace PetShop6.Models
{
    public class DataContext:IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<AnimalModel> Animals { get; set; }
        public DbSet<CategoriesModel> Cateries { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserRoleModel> UserRoles { get; set; }

    }
}
