using AutoMapper;
using BlazorEcomm_BUSINESS.Repository.IRepository;
using BlazorEcomm_COMMON;
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

    public async Task<OrderDTO> Get(int id)
    {
        /* An order is comprised of order header and order details. */
        Order order = new()
        {
            // NOTE: changed these to async ***
            OrderHeader = await _db.OrderHeaders.FirstOrDefaultAsync(oh => oh.Id == id),
            OrderDetails = await _db.OrderDetails.Where(od => od.Id == id).ToListAsync(),
        };

        if (order is not null)
        {
            return _mapper.Map<Order, OrderDTO>(order);
        }
        return new OrderDTO();
    }


    public async Task<IEnumerable<OrderDTO>> GetAll(string? userId = null, string? status = null)
    {
        List<Order> ordersFromDb = new();
        IEnumerable<OrderHeader> orderHeaderList = _db.OrderHeaders;
        IEnumerable<OrderDetail> orderDetailsList = _db.OrderDetails;

        foreach (OrderHeader header in orderHeaderList)
        {
            Order order = new()
            {
                OrderHeader = header,
                OrderDetails = orderDetailsList.Where(od => od.OrderHeaderId == header.Id)
            };
            ordersFromDb.Add(order);
        }

        // #TODO: list filtering

        return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(ordersFromDb);
    }


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
            /* If the header exists, retrieve all order details based on its Id, delete order 
               header and order details, and save changes to db */
            IEnumerable<OrderDetail> objDetail = _db.OrderDetails.Where(u => u.OrderHeaderId == id);
            _db.OrderDetails.RemoveRange(objDetail);
            _db.OrderHeaders.Remove(objHeader);
            return await _db.SaveChangesAsync();        
        }
        return 0;
    }


    public async Task<OrderHeaderDTO> UpdateHeader(OrderHeaderDTO objDTO)
    {
        if (objDTO is not null)
        {
            var orderHeader = _mapper.Map<OrderHeaderDTO, OrderHeader>(objDTO);
            _db.OrderHeaders.Update(orderHeader);
            await _db.SaveChangesAsync();
            return _mapper.Map<OrderHeader, OrderHeaderDTO>(orderHeader);
        }
        return new OrderHeaderDTO();
    }


    public async Task<OrderHeaderDTO> MarkPaymentSuccessful(int id)
    {
        var data = await _db.OrderHeaders.FindAsync(id);
        //if (data is null) return new OrderHeaderDTO();
        if (data is not null && data.Status == StaticDetails.STATUS_PENDING)
        {
            data.Status = StaticDetails.STATUS_CONFIRMED;
            await _db.SaveChangesAsync();
            return _mapper.Map<OrderHeader, OrderHeaderDTO>(data);
        }

        return new OrderHeaderDTO();
    }


    public async Task<bool> UpdateOrderStatus(int orderId, string status)
    {
        var data = await _db.OrderHeaders.FindAsync(orderId);
        if (data is not null)
        {
            data.Status = status;
            if (status == StaticDetails.STATUS_SHIPPED) data.ShippingDate = DateTime.Now;
            await _db.SaveChangesAsync();
            return true;
        }

        return false;
    }

}
