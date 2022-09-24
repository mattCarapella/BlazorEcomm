using System.ComponentModel.DataAnnotations;

namespace BlazorEcomm_MODELS;

public class ProductPriceDTO
{
    //private ProductPriceDTO()
    //{
    //    Product = null!;
    //}

    [Required]
    public int Id { get; set; }

    [Required,
     Range(0.01, int.MaxValue, ErrorMessage = "Price must be greater than $0.01")]
    public double Price { get; set; }

    // #NOTE: Removed nullable type
    public string Size { get; set; } = String.Empty;    

    // Laptop options
    public string? ScreenSize { get; set; }
    public string? Display { get; set; }
    public string? Memory { get; set; }
    public string? Storage { get; set; }
    public string? CPUModel { get; set; }
    public int CPUCores { get; set; }
    public string? GPU { get; set; }
    public int GPUCores { get; set; }


    public int ProductId { get; set; }

    //public Product Product { get; set; }
}
