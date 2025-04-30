using Microsoft.AspNetCore.Mvc;

namespace TableTap.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
