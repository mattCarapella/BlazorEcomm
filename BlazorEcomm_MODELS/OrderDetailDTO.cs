using System.ComponentModel.DataAnnotations;

namespace BlazorEcomm_MODELS;

public class OrderDetailDTO
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int OrderHeaderId { get; set; }

    [Required]
    public int ProductId { get; set; }

    public ProductDTO Product { get; set; } = new ProductDTO();

    [Required]
    public int Count { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public string Size { get; set; } = string.Empty;


    [Required]
    public string ProductName { get; set; } = string.Empty;
}
