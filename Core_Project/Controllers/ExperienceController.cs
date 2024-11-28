using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager=new ExperienceManager(new EFExperienceDAL());

        public IActionResult Index()
        {
            ViewBag.v1 = "Experience List";
            var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.v1 = "Add Experience";
         
            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            ExperienceValidator validationRules = new ExperienceValidator();
            ValidationResult results = validationRules.Validate(experience);
            if (results.IsValid)
            {
                experienceManager.TAdd(experience);
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
        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetBYID(id);
            experienceManager.TDelete(values);
            return RedirectToAction("Index");



        }
        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            ViewBag.d1 = "Edit Experience";

            var values = experienceManager.TGetBYID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }

    }
}
