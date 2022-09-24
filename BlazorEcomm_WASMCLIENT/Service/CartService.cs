using BlazorEcomm_COMMON;
using BlazorEcomm_WASMCLIENT.Service.IService;
using BlazorEcomm_WASMCLIENT.ViewModels;
using Blazored.LocalStorage;

namespace BlazorEcomm_WASMCLIENT.Service;

public class CartService : ICartService
{
    private readonly ILocalStorageService _localStorage;

    /* We can bind an event to OnChange so that when its called the state will be updated, causing 
       the UI to be re-rendered. Whenever the cart is incremented or decremented, the NavMenu will 
       be informed of the change so it can re-render the UI */
    public event Action? OnChange;

    public CartService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task IncrementCart(ShoppingCart cartToAdd)
    {
        var cart = await _localStorage.GetItemAsync<List<ShoppingCart>>(StaticDetails.ShoppingCart);
        bool itemInCart = false;

        if (cart == null) cart = new List<ShoppingCart>();
    
        foreach (var item in cart)
        {
            if (item.ProductId == cartToAdd.ProductId && item.ProductPriceId == cartToAdd.ProductPriceId)
            {
                // Record already exists in cart
                itemInCart = true;
                item.Count += cartToAdd.Count; 
            }
        }
        if (!itemInCart)
        {
            // Not found so create a new ShoppingCart object
            cart.Add(new ShoppingCart()
            {
                ProductId = cartToAdd.ProductId,
                ProductPriceId = cartToAdd.ProductPriceId,
                Count = cartToAdd.Count
            });    
        }

        // Set LocalStorage with new cart
        await _localStorage.SetItemAsync(StaticDetails.ShoppingCart, cart);

        // Update state and re-render UI
        OnChange!.Invoke();
    }


    public async Task DecrementCart(ShoppingCart cartToDecrement)
    {
        var cart = await _localStorage.GetItemAsync<List<ShoppingCart>>(StaticDetails.ShoppingCart);

        for (int i = 0; i < cart.Count; i++)
        {
            if (cart[i].ProductId == cartToDecrement.ProductId && cart[i].ProductPriceId == cartToDecrement.ProductPriceId)
            {
                /* We have found the object that needs to be decremented or removed. If count is 0 or 1, we should
                   remove the item. Otherwise decrement by amount set in cartToDecrement */
                if (cart[i].Count == 1 || cartToDecrement.Count == 0)
                {
                    cart.Remove(cart[i]);
                }
                else
                {
                    cart[i].Count -= cartToDecrement.Count;
                }
            }
        }

        // Set LocalStorage with new cart
        await _localStorage.SetItemAsync(StaticDetails.ShoppingCart, cart);
        
        // Update state and re-render UI
        OnChange!.Invoke();
    }

}
