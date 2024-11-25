using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
            var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
          experienceManager.TAdd(experience);
          return RedirectToAction("Index");


        }
        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.TGetBYID(id);
            experienceManager.TDelete(values);
            return RedirectToAction("Index");



        }
    }
}
