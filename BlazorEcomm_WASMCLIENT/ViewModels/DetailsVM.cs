using System.ComponentModel.DataAnnotations;

namespace BlazorEcomm_WASMCLIENT.ViewModels;

public class DetailsVM
{
    public DetailsVM()
    {
        ProductPrice = new();
        Count = 1;
    }

    [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than 0.")]
    public int Count { get; set; }

    [Required]
    public int SelectedProductPriceId { get; set; }

    public BlazorEcomm_MODELS.ProductPriceDTO ProductPrice { get; set; }   // Nav property

}