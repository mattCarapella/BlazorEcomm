using BlazorEcomm_MODELS;

namespace BlazorEcomm_WASMCLIENT.Service.IService;

public interface IProductService
{
    public Task<IEnumerable<ProductDTO>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO> Get(int id)
    {
        throw new NotImplementedException();
    }
}
