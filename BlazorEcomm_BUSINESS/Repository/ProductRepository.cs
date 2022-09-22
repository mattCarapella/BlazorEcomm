using AutoMapper;
using BlazorEcomm_BUSINESS.Repository.IRepository;
using BlazorEcomm_DATA;
using BlazorEcomm_DATA.Data;
using BlazorEcomm_MODELS;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcomm_BUSINESS.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ProductDTO> Create(ProductDTO objDTO)
    {
        var obj = _mapper.Map<ProductDTO, Product>(objDTO);
        obj.DateAdded = DateTime.Now;
        var addedObj = _db.Products.Add(obj);
        await _db.SaveChangesAsync();
        return _mapper.Map<Product, ProductDTO>(addedObj.Entity);
    }

    public async Task<ProductDTO> Get(int id)
    {
        var obj = await _db.Products.Include(p => p.Category)
                                    .Include(p => p.ProductPrices)
                                    .FirstOrDefaultAsync(p => p.Id == id);

        if (obj is not null) return _mapper.Map<Product, ProductDTO>(obj);
        return new ProductDTO();
    }

    public async Task<IEnumerable<ProductDTO>> GetAll()
    {
        var obj = await _db.Products.Include(p => p.Category)
                                    .Include(p => p.ProductPrices)
                                    .ToListAsync();
        return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(obj);
    }

    public async Task<ProductDTO> Update(ProductDTO objDTO)
    {
        var obj = await _db.Products.FirstOrDefaultAsync(p => p.Id == objDTO.Id);
        if (obj is not null)
        {
            obj.Name = objDTO.Name;
            obj.Description = objDTO.Description;
            obj.ImageUrl = objDTO.ImageUrl;
            obj.Brand = objDTO.Brand;
            obj.Color = objDTO.Color;
            obj.StoreFavorite = objDTO.StoreFavorite;
            obj.CustomerFavorite = objDTO.CustomerFavorite;
            obj.CategoryId = objDTO.CategoryId;
            obj.DateUpdated = DateTime.Now;
            _db.Products.Update(obj);
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(obj);
        }
        return objDTO;
    }

    public async Task<int> Delete(int id)
    {
        var obj = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (obj is not null)
        {
            _db.Products.Remove(obj);
            await _db.SaveChangesAsync();
        }
        return 0;
    }

}
