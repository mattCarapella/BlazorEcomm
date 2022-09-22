using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcomm_DATA;

public class ProductPrice
{
    private ProductPrice()
    {
        Product = null!;
    }

    public int Id { get; set; }
    public double Price { get; set; }
    public string? Size { get; set; }

    // Laptop options
    public string? ScreenSize { get; set; }
    public string? Display { get; set; }
    public string? Memory { get; set; }
    public string? Storage { get; set; }
    public string? CPUModel { get; set; }
    public int CPUCores { get; set; }
    public string? GPU { get; set; }
    public int GPUCores { get; set; }



    // Foreign key to product table
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }

}
