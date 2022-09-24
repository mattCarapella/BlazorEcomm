using BlazorEcomm_MODELS;
using BlazorEcomm_WASMCLIENT.Service.IService;
using Newtonsoft.Json;

namespace BlazorEcomm_WASMCLIENT.Service;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<OrderDTO> Get(int orderHeaderId)
    {
        // Send API request to controller which then uses repository to get product data
        // _httpClient.GetAsync(...) is getting API route url that is stored in appsettings.json
        var response = await _httpClient.GetAsync($"/api/orders/{orderHeaderId}");

        // ReadAsString serializes the http response
        var content = await response.Content.ReadAsStringAsync();
    
        if (response.IsSuccessStatusCode)
        {
            var order = JsonConvert.DeserializeObject<OrderDTO>(content);
            if (order is not null) return order;
            return new OrderDTO();
        }
        else
        {
            var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
            throw new Exception(errorModel!.ErrorMessage);
        }
    }


    public async Task<IEnumerable<OrderDTO>> GetAll(string? userId)
    {
        var response = await _httpClient.GetAsync($"/api/orders");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<IEnumerable<OrderDTO>>(content);
            if (orders is not null) return orders;
        }
        return new List<OrderDTO>();
    }
}
