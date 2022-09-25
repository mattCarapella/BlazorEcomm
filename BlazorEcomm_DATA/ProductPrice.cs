using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcomm_DATA;

public class ProductPrice
{
    public int Id { get; set; }
    public double Price { get; set; }
    public string Size { get; set; } = String.Empty;

    // Laptop options
    public string? ScreenSize { get; set; } = String.Empty;
    public string? Display { get; set; } = String.Empty;
    public string? Memory { get; set; } = String.Empty;
    public string? Storage { get; set; } = String.Empty;
    public string? CPUModel { get; set; } = String.Empty;
    public int CPUCores { get; set; }
    public string? GPU { get; set; } = String.Empty;
    public int GPUCores { get; set; }


    // Foreign key to product table
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; } = new Product();

}
