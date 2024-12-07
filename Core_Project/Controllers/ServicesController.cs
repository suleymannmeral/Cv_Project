using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class ServicesController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceDAL());
        public IActionResult Index()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
          
            ServicesValidator validationRules = new ServicesValidator();
            ValidationResult results = validationRules.Validate(service);
            if (results.IsValid)
            {
                serviceManager.TAdd(service);
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
        public IActionResult DeleteService(int id)
        {
            var values = serviceManager.TGetBYID(id);
            serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            ViewBag.tt = "Edit Service Page";
            var values = serviceManager.TGetBYID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {
         

            ServicesValidator validationRules = new ServicesValidator();
            ValidationResult results = validationRules.Validate(service);
            if (results.IsValid)
            {
                serviceManager.TUpdate(service);
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
