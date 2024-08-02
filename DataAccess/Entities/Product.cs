using System.ComponentModel;

namespace DataAccess.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public bool Status { get; set; }
    public virtual ICollection<OrderDetails> OrderDetails { get; set; }
}