using B2C.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B2C.Infrastructure.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customer");
        builder.HasKey(x => x.Id);
        builder.Property(v => v.Id)
               .HasConversion(
                Id => Id.Value,
                value => CustomerId.GetNew(value)
               );
               
        builder.OwnsOne(c => c.Details, d => 
                {
                  d.ToJson();
                  d.OwnsMany(d => d.Orders);
                });
  }
}
