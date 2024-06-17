using Microsoft.AspNetCore.Mvc;

namespace Sales.WebApp.Controllers;

public class ProductosController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}