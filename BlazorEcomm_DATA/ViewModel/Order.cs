namespace BlazorEcomm_DATA.ViewModel;

public class Order
{
    public OrderHeader OrderHeader { get; set; } = new();
    public IEnumerable<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

}
