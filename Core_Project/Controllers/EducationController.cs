using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class EducationController : Controller
    {
        EducationManager educationManager = new EducationManager(new EFEducationDAL());

        public IActionResult Index()
        {
            ViewBag.v1 = "Education List";
            var values = educationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddEducation()
        {
            ViewBag.v1 = "Add Education";
            return View();
        }
        [HttpPost]
        public IActionResult AddEducation(Education education)
        {
            
            EducationValidator validationRules = new EducationValidator();
            ValidationResult results = validationRules.Validate(education);
            if (results.IsValid)
            {
                educationManager.TAdd(education);
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
        public IActionResult DeleteEducation(int id)
        {
            var values= educationManager.TGetBYID(id);
            educationManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditEducation(int id)
        {
            ViewBag.v1 = "Edit Education";
            var values = educationManager.TGetBYID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditEducation(Education education)
        {
         
            EducationValidator validationRules = new EducationValidator();
            ValidationResult results = validationRules.Validate(education);
            if (results.IsValid)
            {
                educationManager.TUpdate(education);
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



    }
}
