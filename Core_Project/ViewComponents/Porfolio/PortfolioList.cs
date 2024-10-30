using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Porfolio
{
    public class PortfolioList:ViewComponent
    {
        PortfolioManager portfolioManager=new PortfolioManager(new EFPortfolioDAL());

        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList();
            return View(values);
        }

    }
}
