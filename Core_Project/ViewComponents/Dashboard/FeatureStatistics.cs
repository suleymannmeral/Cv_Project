using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class FeatureStatistics : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.s1 = c.Skills.Count();
            ViewBag.s2=c.Messages.Where(x=>x.Status==false).Count(); //Unreaded Message
            ViewBag.s3=c.Messages.Where(x=>x.Status==true).Count(); //Unreaded Message
            ViewBag.s4=c.Experiences.Count(); //Exoperience Count
            return View();
        }
    }
}
