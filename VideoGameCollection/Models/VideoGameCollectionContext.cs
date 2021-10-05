using Microsoft.EntityFrameworkCore;

namespace VideoGameCollection.Models
{
  public class VideoGameCollectionContext : DbContext
  {
    public DbSet<Game> Games { get; set; }

    public VideoGameCollectionContext(DbContextOptions options) : base(options) { }
  }
}