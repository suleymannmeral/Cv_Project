using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminAnnouncementsController : Controller
    {
        AnnouncementsManager announcementsMnager = new AnnouncementsManager(new EFAnnouncementsDAL());

        public IActionResult AnnouncementsList()
        {
            var values = announcementsMnager.TGetList();
            return View(values);
        }
      
    }
}
