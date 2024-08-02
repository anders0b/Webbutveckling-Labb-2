namespace Common.Models;

public class CategoryModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<ProductModel> Products { get; set; }
}