using BlazorEcomm_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcomm_BUSINESS.Repository.IRepository;

public interface IProductRepository
{
    public Task<ProductDTO> Create(ProductDTO objDTO);

    public Task<ProductDTO> Get(int id);

    public Task<IEnumerable<ProductDTO>> GetAll();

    public Task<ProductDTO> Update(ProductDTO objDTO);

    public Task<int> Delete(int id);
}
