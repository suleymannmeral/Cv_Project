using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Skill
{
    public class SkillList:ViewComponent
    {
        SkillManager skillManager = new SkillManager(new EFSkillDAL());

        public IViewComponentResult Invoke()

        {
           var values=skillManager.TGetList();
            return View(values);
        }
    }
}
