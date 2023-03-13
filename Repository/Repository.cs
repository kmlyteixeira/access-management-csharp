using Microsoft.EntityFrameworkCore;

namespace Repository
{
  public class Context : DbContext
  {
    public DbSet<Models.Users> Users { get; set; }
    public DbSet<Models.Profiles> Profiles { get; set; }
    public DbSet<Models.Sessions> Sessions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySql("Server=localhost;User Id=root;Database=accessmanage");
    }
  }
}