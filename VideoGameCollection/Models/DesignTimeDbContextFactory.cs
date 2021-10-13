using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace VideoGameCollection.Models
{
  public class VideoGameCollectionContextFactory : IDesignTimeDbContextFactory<VideoGameCollectionContext>
  {

    VideoGameCollectionContext IDesignTimeDbContextFactory<VideoGameCollectionContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<VideoGameCollectionContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new VideoGameCollectionContext(builder.Options);
    }
  }
}