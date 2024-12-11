using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class StatisticsDashboard2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.ss1 = c.Portfolios.Count(); //Project Count
            return View();
        }
    }
}
