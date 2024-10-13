using Microsoft.EntityFrameworkCore;

namespace EfCorePostgreSqlDbContext
{
  public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Server=127.0.0.1;Port=5432;Database=postgres;User Id=postgres;Password=postgres;");
    }
}
}