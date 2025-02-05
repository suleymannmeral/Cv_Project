using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]

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
            PortfolioValidator validationRules = new PortfolioValidator();
            ValidationResult results=validationRules.Validate(portfolio);
            if (results.IsValid)
            {
                portgolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            
           
        }

        public IActionResult DeletePortfolio(int id)
        {
            var values= portgolioManager.TGetBYID(id);
            portgolioManager.TDelete(values);
           return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            var values = portgolioManager.TGetBYID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
         
            if (portfolio.Completion == 100)
            {
                portfolio.Status = true;
            }
            else
            {
                portfolio.Status = false;
            }
            portgolioManager.TUpdate(portfolio);
            return RedirectToAction("Index");
        }
    }
}
