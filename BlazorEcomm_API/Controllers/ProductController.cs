using BlazorEcomm_BUSINESS.Repository.IRepository;
using BlazorEcomm_MODELS;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcomm_API.Controllers;

[Route("api/[controller]s")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository; 
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _productRepository.GetAll());
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int? id)
    {
        if (id == null || id == 0)
        {
            return BadRequest(new ErrorModelDTO()
            {
                ErrorMessage = "Invalid ID",
                StatusCode = StatusCodes.Status400BadRequest
            });
        }
        
        var product = await _productRepository.Get(id.Value);
        if (product == null)
        {
            return BadRequest(new ErrorModelDTO()
            {
                ErrorMessage = "Product not found",
                StatusCode = StatusCodes.Status404NotFound
            });
        }

        return Ok(product);
    }


}
