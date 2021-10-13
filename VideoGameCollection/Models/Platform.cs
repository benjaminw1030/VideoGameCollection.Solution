using System.Collections.Generic;

namespace VideoGameCollection.Models
{
  public class Platform
  {
    public Platform()
    {
      this.JoinEntities = new HashSet<GamePlatform>();
    }

    public int PlatformId { get; set; }
    public string Name { get; set; }
    public int ReleaseYear { get; set; }
    public virtual ICollection<GamePlatform> JoinEntities { get; set;}
  }
}