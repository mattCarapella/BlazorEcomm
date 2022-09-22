using AutoMapper;
using BlazorEcomm_BUSINESS.Repository.IRepository;
using BlazorEcomm_DATA;
using BlazorEcomm_DATA.Data;
using BlazorEcomm_MODELS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcomm_BUSINESS.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public CategoryRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<CategoryDTO> Create(CategoryDTO objDTO)
    {
        var obj = _mapper.Map<CategoryDTO, Category>(objDTO);
        obj.CreatedDate = DateTime.Now;
        var addedObj = _db.Categories.Add(obj);
        await _db.SaveChangesAsync();
        return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
    }

    public async Task<int> Delete(int id)
    {
        var obj = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (obj is not null)
        {
            _db.Categories.Remove(obj);
            return await _db.SaveChangesAsync();
        }
        return 0;
    }

    public async Task<CategoryDTO> Get(int id)
    {
        var obj = await _db.Categories.FirstOrDefaultAsync(c => c.Id == id);
        if (obj is not null) return _mapper.Map<Category, CategoryDTO>(obj);
        return new CategoryDTO();
    }

    public async Task<IEnumerable<CategoryDTO>> GetAll()
    {
        var obj = await _db.Categories.ToListAsync();
        return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(obj);
    }

    public async Task<CategoryDTO> Update(CategoryDTO objDTO)
    {
        var obj = await _db.Categories.FirstOrDefaultAsync(c => c.Id == objDTO.Id);
        if (obj is not null)
        {
            obj.Name = objDTO.Name;
            obj.UpdatedDate = DateTime.Now;
            _db.Categories.Update(obj);
            await _db.SaveChangesAsync();
            return _mapper.Map<Category, CategoryDTO>(obj);
        }
        return objDTO;
    }
}













//public async Task<CategoryDTO> Create(CategoryDTO objDTO)
//{
// Convert DTO to category object, add to db, and return a DTO

//Category category = new Category()
//{
//    Id = objDTO.Id,
//    Name = objDTO.Name,
//    CreatedDate = objDTO.CreatedDate
//};

//_db.Categories.Add(category);
//_db.SaveChanges();

//return new CategoryDTO()
//{
//    Id = category.Id,
//    Name = category.Name,
//    CreatedDate = category.CreatedDate
//};


/* 
 * The above can be simplified using AutoMapper
*/
//    var obj = _mapper.Map<CategoryDTO, Category>(objDTO);
//    obj.CreatedDate = DateTime.Now;
//    var addedObj = _db.Categories.Add(obj);
//    await _db.SaveChangesAsync();

//    return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);

//}
