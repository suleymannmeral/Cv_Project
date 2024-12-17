using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.Controllers
{
    public class RegisterController : Controller
    {
        [Area("Writer")]

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(String p)
        {
            return View();
        }
    }
}
