using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
         
            SkillValidator validationRules = new SkillValidator();
            ValidationResult results = validationRules.Validate(skill);
            if (results.IsValid)
            {
                skillManager.TAdd(skill);
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
            SkillValidator validationRules = new SkillValidator();
            ValidationResult results = validationRules.Validate(skill);
            if (results.IsValid)
            {

                skillManager.TUpdate(skill);
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
