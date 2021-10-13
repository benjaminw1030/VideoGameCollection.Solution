using Microsoft.EntityFrameworkCore;

namespace VideoGameCollection.Models
{
  public class VideoGameCollectionContext : DbContext
  {
    public DbSet<Game> Games { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<GamePlatform> GamePlatform { get; set; }

    public VideoGameCollectionContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}