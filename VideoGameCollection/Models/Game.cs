using System;
using System.Collections.Generic;

namespace VideoGameCollection.Models
{
  public class Game
  {

    public Game()
    {
      this.JoinEntities = new HashSet<GamePlatform>();
    }
    public int GameId { get; set; }
    public string Title { get; set; }

    public string Genre { get; set; }

    public int MetaScore { get; set; }

    public DateTime ReleaseDate { get; set; }
    public virtual ICollection<GamePlatform> JoinEntities { get; set; }
  }
}