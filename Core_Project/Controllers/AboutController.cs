using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDAL()); 
        public IActionResult Index()
        {
            var values = aboutManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            var values=aboutManager.TGetBYID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAbout(About about)
        {
            aboutManager.TUpdate(about);
            return RedirectToAction("Index");
        }
    }
}
