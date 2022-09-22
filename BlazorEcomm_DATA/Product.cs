using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcomm_DATA;

public class Product
{
    private Product()
    {
        Category = null!;
    }

    public int Id { get; set; }

    [Required,
     MinLength(2, ErrorMessage = "Product name must be at least 2 characters."),
     MaxLength(100, ErrorMessage = "Product name must be less than 50 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required,
     MinLength(2, ErrorMessage = "Product brand must be at least 2 characters."),
     MaxLength(40, ErrorMessage = "Product brand must be less than 40 characters.")]
    public string Brand { get; set; } = string.Empty;

    [Required,
     MinLength(3, ErrorMessage = "Product description must be at least 3 characters."),
     MaxLength(1000, ErrorMessage = "Product name must be less than 500 characters.")]
    public string Description { get; set; } = string.Empty;

    public bool StoreFavorite { get; set; }

    public bool CustomerFavorite { get; set; }

    [MinLength(2, ErrorMessage = "Product color must be at least 3 characters."),
     MaxLength(50, ErrorMessage = "Product color must be less than 30 characters.")]
    public string? Color { get; set; }

    public string? ImageUrl { get; set; }


    [Display(Name = "Date Added"), 
     DataType(DataType.Date)]
    public DateTime DateAdded { get; set; }

    [Display(Name = "Last Updated"), 
     DataType(DataType.Date)]
    public DateTime? DateUpdated { get; set; }


    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }

    public ICollection<ProductPrice> ProductPrices { get; set; } = new List<ProductPrice>();
}
