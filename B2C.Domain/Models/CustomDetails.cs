namespace B2C.Domain.Models;

public record CustomerDetails
{
  public string Name { get; set; }
  public int Age { get; set; }
  public List<Order> Orders { get; set; }

}