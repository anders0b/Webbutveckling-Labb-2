namespace Common.Models;

public class OrderModel
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateOnly OrderDate { get; set; }
    public bool IsShipped { get; set; }
    public virtual ICollection<OrderDetailsModel> OrderDetails { get; set; }
}