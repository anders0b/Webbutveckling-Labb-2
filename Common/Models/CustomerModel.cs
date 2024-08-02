using System.ComponentModel.DataAnnotations;

namespace Common.Models;

public class CustomerModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string Phone { get; set; }
    public string StreetAddress { get; set; }
    public int PostalCode { get; set; }
    public string City { get; set; }
    public virtual ICollection<OrderModel> Orders { get; set; }
}