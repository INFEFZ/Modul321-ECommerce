using Microsoft.EntityFrameworkCore;

namespace CustomerService.Models
{
  public class CustomerDbContext : DbContext
  {
    public CustomerDbContext(DbContextOptions options) 
            : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; } = null!;
  }
}
