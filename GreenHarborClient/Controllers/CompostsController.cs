using Microsoft.AspNetCore.Mvc;
using GreenHarborClient.Models;

namespace GreenHarborClient.Controllers;

public class CompostsController : Controller
{
  public IActionResult Index()
  {
    List<Compost> composts = Compost.GetComposts();
    return View(composts);
  }

  public IActionResult Details(int id)
  {
    Compost compost = Compost.GetDetails(id);
    return View(compost);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Compost compost)
  {
    Compost.Post(compost);
    return RedirectToAction("Index");
  }

   public ActionResult Edit(int id)
  {
    Compost compost = Compost.GetDetails(id);
    return View(compost);
  }

  [HttpPost]
  public ActionResult Edit(Compost compost)
  {
    Compost.Put(compost);
    return RedirectToAction("Details", new { id = compost.CompostId});
  }

  public ActionResult Delete(int id)
  {
    Compost compost = Compost.GetDetails(id);
    return View(compost);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Compost.Delete(id);
    return RedirectToAction("Index");
  }
}