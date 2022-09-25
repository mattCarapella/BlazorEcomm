using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcomm_DATA.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    { 
    }
    
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductPrice> ProductPrices { get; set; } = null!;
    public DbSet<OrderHeader> OrderHeaders { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

}
