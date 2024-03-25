using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers;

public class HomerController : Controller
{
    private readonly ILogger<HomerController> _logger;

    private string _now = "hello";
    private int counter = 0;

    public HomerController(ILogger<HomerController> logger)
    {
        _logger = logger;
        while(counter == 1){
            ;
        }
        // Console.WriteLine("Homer created");
        
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privaco()
    {
        counter++;
        // if(_now == "hello"){
        //     _now = "World";
        // }
        // else{
        //     _now = "hello";
        // }
        _now = counter.ToString();
        ViewResult view1;
        ViewResult view2;
        view1 = View(model:"<h2>HeLlo</h2>");
        view2 = View(model:"hello");
        // view1 = View("Index");
        return view1;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
