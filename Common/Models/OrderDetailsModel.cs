namespace Common.Models;

public class OrderDetailsModel
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public OrderModel Order { get; set; }
    public ProductModel Product { get; set; }
}