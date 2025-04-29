using Microsoft.AspNetCore.Mvc;

namespace TableTap.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
