using BlazorEcomm_MODELS;

namespace BlazorEcomm_WASMCLIENT.Service.IService;

public interface IProductService
{
    public Task<ProductDTO> Get(int id);
    public Task<IEnumerable<ProductDTO>> GetAll();
}
