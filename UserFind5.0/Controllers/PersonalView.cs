using Microsoft.AspNetCore.Mvc;

namespace UserFind5._0.Controllers
{
    public class PersonalView : Controller
    {
        public IActionResult Index()
        {
            return View("Danya");
        }

        public IActionResult Danya() 
        {
            return View(); 
        }

        public IActionResult Pasha()
        {
            return View();
        }

        public IActionResult Geka()
        {
            return View();
        }

        public IActionResult Vova()
        {
            return View();
        }
    }
}