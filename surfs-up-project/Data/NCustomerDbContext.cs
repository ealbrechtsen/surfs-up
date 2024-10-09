using Microsoft.EntityFrameworkCore;
using surfs_up_project.Models;

public class NCustomerDbContext : DbContext
{

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public NCustomerDbContext(DbContextOptions<NCustomerDbContext> options) : base(options)
    {
    
    }

    
}
