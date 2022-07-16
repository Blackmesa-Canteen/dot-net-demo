using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers;

public class IndexController : Controller
{
    // GET
    public IActionResult Index()
    {
        string value = "datatata";
        ViewBag.value = value;
        return View();
    }
}