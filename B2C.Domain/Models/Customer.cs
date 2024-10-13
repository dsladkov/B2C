namespace B2C.Domain.Models;
public class Customer : Entity<CustomerId>
{
  //public Guid Id { get; set; }
  public CustomerDetails? Details { get; set; }

  private Customer(CustomerId id) : base(id) {}

  public Customer
  (
    CustomerId id, 
    CustomerDetails? cusomerDetails
  ) : base(id) 
  {
    Details = cusomerDetails;
  }
  
}