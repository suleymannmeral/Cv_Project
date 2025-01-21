using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.ViewComponents
{
    public class Notifications: ViewComponent
    {
        AnnouncementsManager announcementsManager = new AnnouncementsManager(new EFAnnouncementsDAL());
        public IViewComponentResult Invoke()
        {
            var values = announcementsManager.TGetList().Take(3).ToList();

            return View(values);
        }
    }
}
