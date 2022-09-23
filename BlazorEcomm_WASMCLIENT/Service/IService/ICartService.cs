using BlazorEcomm_WASMCLIENT.ViewModels;

namespace BlazorEcomm_WASMCLIENT.Service.IService;

public interface ICartService
{
    Task IncrementCart(ShoppingCart shoppingCart);
    Task DecrementCart(ShoppingCart shoppingCart);
}
