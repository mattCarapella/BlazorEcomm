using BlazorEcomm_BUSINESS.Repository.IRepository;
using BlazorEcomm_MODELS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcomm_API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
     
    public OrdersController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _orderRepository.GetAll());
    }


    [HttpGet("{orderHeaderId}")]
    public async Task<IActionResult> Get(int? orderHeaderId)
    {
        if (orderHeaderId == null || orderHeaderId == 0)
        {
            return BadRequest(new ErrorModelDTO()
            {
                ErrorMessage = "Invalid order header ID.",
                StatusCode = StatusCodes.Status400BadRequest
            });
        }

        var orderHeader = await _orderRepository.Get(orderHeaderId.Value);
        if (orderHeader is null)
        {
            return BadRequest(new ErrorModelDTO()
            {
                ErrorMessage = "Invalid ID.",
                StatusCode = StatusCodes.Status404NotFound
            });
        }

        return Ok(orderHeader);
    }

}
