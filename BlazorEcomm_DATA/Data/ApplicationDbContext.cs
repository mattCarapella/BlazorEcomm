using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcomm_DATA.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    { 
    }

    //public DbSet<Category> Categories { get; set; }
    //public DbSet<Product> Products { get; set; }
    //public DbSet<ProductPrice> ProductPrices { get; set; }
    //public DbSet<OrderHeader> OrderHeaders { get; set; }
    //public DbSet<OrderDetail> OrderDetails { get; set; }
    //public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    //public DbSet<Category> Categories { get; set; } = null!;
    //public DbSet<Product> Products { get; set; } = null!;
    //public DbSet<ProductPrice> ProductPrices { get; set; } = null!;
    //public DbSet<OrderHeader> OrderHeaders { get; set; } = null!;
    //public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    //public DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductPrice> ProductPrices => Set<ProductPrice>();
    public DbSet<OrderHeader> OrderHeaders => Set<OrderHeader>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();


}
