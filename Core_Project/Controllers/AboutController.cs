using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDAL()); 
        public IActionResult Index()
        {
            var values = aboutManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            var values=aboutManager.TGetBYID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAbout(About about)
        {
            AboutValidator aboutValidator = new AboutValidator();
            ValidationResult result= aboutValidator.Validate(about);
            if (result.IsValid)
            {
                aboutManager.TUpdate(about);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
            
        }
    }
}
