using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
