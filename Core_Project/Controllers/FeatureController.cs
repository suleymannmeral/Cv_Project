using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EFFeatureDAL());
        public IActionResult Index()
        {
            var values = featureManager.TGetList();
            return View(values);
        }
    }
}
