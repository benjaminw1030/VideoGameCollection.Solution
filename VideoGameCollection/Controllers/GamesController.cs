using Microsoft.AspNetCore.Mvc;
using VideoGameCollection.Models;
using System.Collections.Generic;
using System.Linq;

namespace VideoGameCollection.Controllers
{
  public class GamesController : Controller
  {
    private readonly VideoGameCollectionContext _db;

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Game game)
    {
        _db.Games.Add(game);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    // [HttpPost]
    // public ActionResult Sort(string sortMethod)
    // {
    //   return RedirectToAction("Index");
    // }

    public GamesController(VideoGameCollectionContext db)
    {
      _db = db;
    }

    public ActionResult Index(string sortMethod)
    {
      List<Game> model = new List<Game> { };
      List<Game> modelToSort = _db.Games.ToList();
      // if (sortMethod == "breed")
      // {
      //   model = modelToSort.OrderBy(animal => animal.Breed).ToList();
      // }
      // else if (sortMethod == "type")
      // {
      //   model = modelToSort.OrderBy(animal => animal.Type).ToList();
      // }
      // else if (sortMethod =="dateRecent")
      // {
      //   model = modelToSort.OrderByDescending(animal => animal.DateOfAdmittance).ToList();
      // }
      // else if (sortMethod =="dateOldest")
      // {
      //   model = modelToSort.OrderBy(animal => animal.DateOfAdmittance).ToList();
      // }
      // else
      // {
        model = modelToSort;
      // }
      return View(model);
    }

    public ActionResult Details(int id)
    {
    Game thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
    return View(thisGame);
    }
  }
}