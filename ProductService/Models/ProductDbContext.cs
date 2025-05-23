using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProductService.Models
{
  public class ProductDbContext : DbContext
  {
        //protected readonly IConfiguration? _configuration;

    public ProductDbContext(DbContextOptions options) 
        : base(options)
    {

    }

    //public ProductDbContext(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //}

    //protected override void OnConfiguring(DbContextOptionsBuilder options)
    //{
    //    options.UseSqlServer(_configuration?.GetConnectionString("DefaultConnection"));
    //}

    public DbSet<Product> Products { get; set; } = null!;
  }
}
