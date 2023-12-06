using Microsoft.AspNetCore.Mvc;
using GreenHarborClient.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace GreenHarborClient.Controllers
{
[Authorize]
public class CompostsController : Controller
{
  private readonly GreenHarborClientContext _db;
  private readonly UserManager<ApplicationUser> _userManager;

  public CompostsController(UserManager<ApplicationUser> userManager, GreenHarborClientContext db)
  {
    _userManager = userManager;
    _db = db;
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Compost compost)
  {
    if(!ModelState.IsValid)
    {
      return View("Index");
    }
    Compost.Post(compost);
    return RedirectToAction("Index");
  }

  public IActionResult Index()
  {
    List<Compost> composts = Compost.GetComposts();
    return View(composts);
  }

  public IActionResult IndexByZip(string zip)
  {
    ViewData["Zip"] = zip;
    List<Compost> composts = Compost.GetCompostsByZip(zip);
    return View(composts);
  }

  public IActionResult IndexByCity(string city)
  {
    ViewData["City"] = city;
    List<Compost> composts = Compost.GetCompostsByCity(city);
    return View(composts);
  }

  public IActionResult IndexByContents(string contents)
  {
    ViewData["Contents"] = contents;
    List<Compost> composts = Compost.GetCompostsByContents(contents);
    return View(composts);
  }

  public IActionResult Details(int id)
  {
    Compost compost = Compost.GetDetails(id);
    return View(compost);
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
    return RedirectToAction("Details", new { id = compost.CompostId });
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
}

