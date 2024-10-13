namespace B2C.Domain.Models;

public record CustomerId
{
  public Guid Value { get; }
  private CustomerId(Guid id) => Value = id;

  public static CustomerId GetNew(Guid guid) => new (guid);
}