using System;

namespace VideoGameCollection.Models
{
  public class Game
  {
    public int GameId { get; set; }
    public string Title { get; set; }

    public string Genre { get; set; }

    public int MetaScore { get; set; }

    public DateTime ReleaseDate { get; set; }
  }
}