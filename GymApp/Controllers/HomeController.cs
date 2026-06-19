using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
