namespace BlazorEcomm_MODELS;

public class OrderDTO
{
    public OrderHeaderDTO OrderHeader { get; set; } = new();
    public List<OrderDetailDTO> OrderDetails { get; set; } = new();

}
