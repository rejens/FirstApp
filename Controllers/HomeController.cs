using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstApp.Models;


namespace FirstApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var list = new List<StudentVm>()
        {
            // new StudentVm() { Id = 1, Name = "rejens", Address = "dhulabari" },
            // new StudentVm() { Id = 2, Name = "rakesh", Address = "chandragadi" }
            
            new StudentVm(  1,  "rejens",  "dhulabari" ),
            new StudentVm( 2,  "rakesh",  "chandragadi")
        };
        return View(list);
    }

    public IActionResult Privacy()
    {
        return View();
    }

        public IActionResult Test()
    {
        return View();
    }

    [HttpGet]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public IActionResult New(TestVm vm)
    {
        //save the parameter to database
        return RedirectToAction("index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
