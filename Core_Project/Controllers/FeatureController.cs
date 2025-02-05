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

    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EFFeatureDAL());
        public IActionResult Index()
        {
            ViewBag.tt = "Feature List Table";
            var values = featureManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult EditFeature(int id)
        {
            ViewBag.tt = "Edit Feature Page";
            var values = featureManager.TGetBYID(id);
            return View(values);

        }

        [HttpPost]
        public IActionResult EditFeature(Feature feature)
        {
           
            FeatureValidator validationRules = new FeatureValidator();
            ValidationResult results = validationRules.Validate(feature);
            if (results.IsValid)
            {
                featureManager.TUpdate(feature);
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
