using BlazorEcomm_MODELS;
using BlazorEcomm_WASMCLIENT.Service.IService;
using Newtonsoft.Json;

namespace BlazorEcomm_WASMCLIENT.Service;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;
    private readonly string _baseServerUrl;

    public ProductService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
        _baseServerUrl = _config.GetSection("BaseServerUrl").Value;
    }

    public async Task<ProductDTO> Get(int productId)
    {
        // Send API request to controller which then uses repository to get product data
        // _httpClient.GetAsync(...) is getting API route url that is stored in appsettings.json
        var response = await _httpClient.GetAsync($"/api/products/{productId}");

        // ReadAsString serializes the http response
        var content = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            // Extract content as JSON if response is successful then deserialize and return product
            var product = JsonConvert.DeserializeObject<ProductDTO>(content);

            if (product == null)
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
                throw new Exception(errorModel!.ErrorMessage);
            }
        
            // product.ImageUrl is currently saved with only the path to {ClientProject}/wwwroot/images. We need to append the server URL path.
            product.ImageUrl = _baseServerUrl + product.ImageUrl;
            return product;
        }
        else
        {
            // Sends back ErrorModelDTO if response is unsuccessful
            var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
            throw new Exception(errorModel!.ErrorMessage);
        }
    }

    public async Task<IEnumerable<ProductDTO>> GetAll()
    {
        var response = await _httpClient.GetAsync("/api/products");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(content);
            
            foreach (var product in products!)
            {
                product.ImageUrl = _baseServerUrl + product.ImageUrl;
            }
            return products;
        }
        return new List<ProductDTO>();
    }
}
