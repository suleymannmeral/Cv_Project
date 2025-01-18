using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class DefaultController : Controller
    {
        AnnouncementsManager announcementsManager = new AnnouncementsManager(new EFAnnouncementsDAL());

        public IActionResult Index()
        {
            var values = announcementsManager.TGetList();
            return View(values);
        }

        //[HttpGet]
        //public IActionResult AnnouncementsDetails(int id)
        //{
        //    Announcements announcement = announcementsManager.TGetBYID(id);
        //    return View(announcement);
        //}
        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        } 
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialThemeSettings()
        {
            return PartialView();
        }
        public PartialViewResult RightSideBar()
        {
            return PartialView();
        }


    }
}
