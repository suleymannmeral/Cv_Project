using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.ViewComponents
{
    public class Notifications: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
