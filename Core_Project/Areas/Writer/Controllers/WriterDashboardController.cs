using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class WriterDashboardController : Controller
    {

        private readonly UserManager<WriterUser> _userManager;

        public WriterDashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            if(User.Identity?.Name == null){
                return NotFound();
            }
            var values = await _userManager.FindByNameAsync(User.Identity.Name); // oturum açmış kullanıcının bilgileri
            ViewBag.v=values?.Name+" "+values?.Surname;

            //weather api

            string api = "54801b2ddfe8d2a526eb025d2cfb6f9f";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=aksaray&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document=XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value")?.Value;

            //Statistics
            Context c = new Context();
            ViewBag.v1 = 0;
            ViewBag.v2=c.Announcements.Count();
            ViewBag.v3 = 0;
            ViewBag.v4 = c.Skills.Count();
            return View();
        }
    }
}
