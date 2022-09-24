using AutoMapper;
using BlazorEcomm_BUSINESS.Repository.IRepository;
using BlazorEcomm_DATA;
using BlazorEcomm_DATA.Data;
using BlazorEcomm_DATA.ViewModel;
using BlazorEcomm_MODELS;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcomm_BUSINESS.Repository;
public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public OrderRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    //public async Task<OrderDTO> Get(int id)
    //{

    //}

    //public async Task<IEnumerable<OrderDTO>> GetAll(string? userId = null, string? status = null)
    //{

    //}
    
    public async Task<OrderDTO> Create(OrderDTO objDTO)
    {
        try
        {
            /* Create order header, retrieve its Id and populate id in order details. */
            var obj = _mapper.Map<OrderDTO, Order>(objDTO);
            _db.OrderHeaders.Add(obj.OrderHeader);
            await _db.SaveChangesAsync();

            /* Once order header is created, loop through order details and populate order header id. This 
               saves changes for all order details in an order. */
            foreach (var details in obj.OrderDetails)
            {
                details.OrderHeaderId = obj.OrderHeader.Id;
            }

            _db.OrderDetails.AddRange(obj.OrderDetails);
            await _db.SaveChangesAsync();

            /* Create a new order with the header and details. */
            return new OrderDTO()
            {
                OrderHeader = _mapper.Map<OrderHeader, OrderHeaderDTO>(obj.OrderHeader),
                OrderDetails = _mapper.Map<IEnumerable<OrderDetail>, IEnumerable<OrderDetailDTO>>(obj.OrderDetails).ToList()
            };
        }
        catch (Exception ex)
        {
            throw ex;
        }
        //return objDTO;
    }

    public async Task<int> Delete(int id)
    {
        /* Using id passed as parameter, retrieve order header from the db. */
        var objHeader = await _db.OrderHeaders.FirstOrDefaultAsync(o => o.Id == id);
        if (objHeader is not null)
        {
            /* If the header exists, retrieve all order details */
            IEnumerable<OrderDetail> objDetail = _db.OrderDetails.Where(u => u.OrderHeaderId == id);
            
            _db.OrderDetails.RemoveRange(objDetail);
            _db.OrderHeaders.Remove(objHeader);
            return await _db.SaveChangesAsync();        
        }
        return 0;
    }

    //public async Task<OrderHeaderDTO> UpdateHeader(OrderHeaderDTO objDTO)
    //{

    //}

    //public async Task<OrderHeaderDTO> MarkPaymentSuccessful(int id)
    //{

    //}

    //public async Task<bool> UpdateOrderStatus(int orderId, string status)
    //{

    //}

}
