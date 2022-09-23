using BlazorEcomm_MODELS;

namespace BlazorEcomm_WASMCLIENT.ViewModels;

public class ShoppingCart
{
    public int ProductId { get; set; }

    public int Count { get; set; }
    
    public ProductDTO Product { get; set; }
    
    public int ProductPriceId { get; set; }
    
    public ProductPriceDTO ProductPrice { get; set; }
    
}
