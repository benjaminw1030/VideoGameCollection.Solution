using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VideoGameCollection.Models;

namespace VideoGameCollection.Controllers
{
  public class PlatformsController : Controller
  {
    private readonly VideoGameCollectionContext _db;

    public PlatformsController(VideoGameCollectionContext db)
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
      return View();
    }

    public ActionResult Create(Platform platform)
    {
      _db.Platforms.Add(platform);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisPlatform = _db.Platforms
        .Include(platform = Platform.JoinEntities)
        .ThenInclude(join => join.Game)
        .FirstOrDefault(platform => platform.PlatformId == id);
      return View(thisPlatform);
    }

    public ActionResult Edit(int id)
    {
      var thisPlatform = _db.Platforms.FirstOrDefault(platform => platform.PlatformId == id);
      return View(thisPlatform);
    }

    [HttpPost]
    public ActionResult Edit(Platform platform)
    {
      _db.Entry(platform).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", platform.PlatformId);
    }

    public ActionResult Delete(int id)
    {
      var thisPlatform = _db.Platforms.FirstOrDefault(platform => platform.PlatformId == id);
      return View(thisPlatform);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPlatform = _db.Platforms.FirstOrDefault(platform => platform.PlatformId == id);
      _db.Platforms.Remove(thisPlatform);
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