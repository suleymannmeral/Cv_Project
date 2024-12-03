using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class NewAdminController : Controller
    {
     public IActionResult Index()
       {
          return View(); 
        }
        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
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
    }
}
