using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class HomerController : Controller
{
    private readonly ILogger<HomerController> _logger;

    public HomerController(ILogger<HomerController> logger)
    {
        _logger = logger;
    }

    public IActionResult Indeo()
    {
        return View();
    }

    public IActionResult Privaco()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
