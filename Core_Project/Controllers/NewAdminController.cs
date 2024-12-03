using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class NewAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
