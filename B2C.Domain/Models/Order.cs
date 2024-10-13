namespace B2C.Domain.Models;

public record Order
{
  public decimal Price { get; set; }
  public string ShippingAddress { get; set; }
}