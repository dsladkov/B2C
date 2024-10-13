using B2C.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace B2C.Infrastructure;

public class ApplicationDbContext(IConfiguration configuration) : DbContext
{
  private const string DATABASE = "Database";

  public DbSet<Customer> Customers => Set<Customer>();

  override protected void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder
      .HasDefaultSchema("core")
      .ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
  }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql(configuration.GetConnectionString( DATABASE)) //configuration.GetConnectionString( DATABASE)
        .UseSnakeCaseNamingConvention()
        .UseLoggerFactory( CreatedLoggerFactory() )
        .EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }

    private ILoggerFactory? CreatedLoggerFactory() =>
        LoggerFactory.Create( builder => { builder.AddConsole();});
}