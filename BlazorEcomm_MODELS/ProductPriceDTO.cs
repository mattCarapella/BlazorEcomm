using System.ComponentModel.DataAnnotations;

namespace BlazorEcomm_MODELS;

public class ProductPriceDTO
{
    [Required]
    public int Id { get; set; }

    [Required,
     Range(0.01, int.MaxValue, ErrorMessage = "Price must be greater than $0.01")]
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

    public int ProductId { get; set; }
}
