using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EFSkillDAL());
        public IActionResult Index()
        {
            ViewBag.d1 = "Skills";

            var values = skillManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.d1 = "Add Skill";
           
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }
       
        public IActionResult DeleteSkill(int id)
        {
            var values=skillManager.TGetBYID(id);
            skillManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.d1 = "Edit Skill";

            var values = skillManager.TGetBYID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }




    }
}
