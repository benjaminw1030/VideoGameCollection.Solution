using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using VideoGameCollection.Models;

namespace VideoGameCollection.Controllers
{
  public class GamesController : Controller
  {
    private readonly VideoGameCollectionContext _db;

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

    public ActionResult Create()
    {
      ViewBag.PlatformId = new SelectList(_db.Platforms, "PlatformId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Game game, int PlatformId)
    {
      _db.Games.Add(game);
      _db.SaveChanges();
      if (PlatformId != 0)
      {
        _db.GamePlatform.Add(new GamePlatform() { GameId = game.GameId, PlatformId = PlatformId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisGame = _db.Games
        .Include(game => game.JoinEntities)
        .ThenInclude(join => join.Platform)
        .FirstOrDefault(game => game.GameId == id);
      return View(thisGame);
    }

    public ActionResult Edit(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
      ViewBag.PlatformId = new SelectList(_db.Platforms, "PlatformId", "Name");
      return View(thisGame);
    }

    [HttpPost]
    public ActionResult Edit(Game game, int PlatformId)
    {
      if (PlatformId != 0)
      {
        _db.GamePlatform.Add(new GamePlatform() { GameId = game.GameId, PlatformId = PlatformId });
      }
      _db.Entry(game).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", game.GameId);
    }

    public ActionResult Delete(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
      return View(thisGame);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisGame = _db.Games.FirstOrDefault(game => game.GameId == id);
      _db.Games.Remove(thisGame);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // [HttpPost]
    // public ActionResult Sort(string sortMethod)
    // {
    //   return RedirectToAction("Index");
    // }
  }
}