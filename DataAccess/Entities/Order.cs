namespace DataAccess.Entities;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateOnly OrderDate { get; set; }
    public bool IsShipped { get; set; }
    public virtual ICollection<OrderDetails> OrderDetails { get; set; }
}