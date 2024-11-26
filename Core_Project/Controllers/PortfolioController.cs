using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portgolioManager = new PortfolioManager(new EFPortfolioDAL());

        public IActionResult Index()
        {
            var values = portgolioManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            portgolioManager.TAdd(portfolio);
            return RedirectToAction("Index");
        }
    }
}
