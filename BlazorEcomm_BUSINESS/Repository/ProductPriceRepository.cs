using AutoMapper;
using BlazorEcomm_BUSINESS.Repository.IRepository;
using BlazorEcomm_DATA;
using BlazorEcomm_DATA.Data;
using BlazorEcomm_MODELS;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcomm_BUSINESS.Repository;

public class ProductPriceRepository : IProductPriceRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ProductPriceRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ProductPriceDTO> Create(ProductPriceDTO objDTO)
    {
        var obj = _mapper.Map<ProductPriceDTO, ProductPrice>(objDTO);
        var addedObj = _db.ProductPrices.Add(obj);
        await _db.SaveChangesAsync();
        return _mapper.Map<ProductPrice, ProductPriceDTO>(addedObj.Entity);
    }

    public async Task<int> Delete(int id)
    {
        var obj = await _db.ProductPrices.FirstOrDefaultAsync(c => c.Id == id);
        if (obj is not null)
        {
            _db.ProductPrices.Remove(obj);
            return await _db.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<ProductPriceDTO> Get(int id)
    {
        var obj = await _db.ProductPrices.FirstOrDefaultAsync(c => c.Id == id);
        if (obj is not null) return _mapper.Map<ProductPrice, ProductPriceDTO>(obj);
        return new ProductPriceDTO();
    }

    public async Task<IEnumerable<ProductPriceDTO>> GetAll(int? id = null)
    {
        var obj = new List<ProductPrice>();

        if (id is not null && id > 0)
        {
            obj = await _db.ProductPrices.Where(p => p.ProductId == id).ToListAsync();
        }
        else
        {
            obj = await _db.ProductPrices.ToListAsync();
        }

        return _mapper.Map<IEnumerable<ProductPrice>, IEnumerable<ProductPriceDTO>>(obj);
    }

    public async Task<ProductPriceDTO> Update(ProductPriceDTO objDTO)
    {
        var obj = await _db.ProductPrices.FirstOrDefaultAsync(c => c.Id == objDTO.Id);
        if (obj is not null)
        {
            obj.ProductId = objDTO.ProductId;
            obj.Price = objDTO.Price;
            obj.Size = objDTO.Size;
            _db.ProductPrices.Update(obj);
            await _db.SaveChangesAsync();
            return _mapper.Map<ProductPrice, ProductPriceDTO>(obj);
        }
        return objDTO;
    }

}
