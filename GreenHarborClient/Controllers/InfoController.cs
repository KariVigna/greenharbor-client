using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GreenHarborClient.Models;

namespace GreenHarborClient.Controllers;

public class InfoController : Controller
{
  private readonly ILogger<InfoController> _logger;

  public InfoController(ILogger<InfoController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View();
  }

  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}