using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json;
using RestSharp;
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

            string api = "54801b2ddfe8d2a526eb025d2cfb6f9f";  //api key
            var client = new RestClient("https://api.collectapi.com/pray/all?data.city=Rize");
            var request = new RestRequest();
            request.AddHeader("authorization", "apikey 0dVafBz9iHTqk8pkvrDFcc:7LOlMOsX24O1beqao62AY0");
            request.AddHeader("content-type", "application/json");
            var response = await client.GetAsync(request);
            if (response.IsSuccessful && response.Content != null)
            {
                var prayerData = JsonConvert.DeserializeObject<dynamic>(response.Content);

             
                string fajr = prayerData.result[0].saat;
                string sunrise = prayerData.result[1].saat;
                string dhuhr = prayerData.result[2].saat;
                string asr = prayerData.result[3].saat;
                string maghrib = prayerData.result[4].saat;
                string isha = prayerData.result[5].saat;
              

          
                Console.WriteLine(prayerData);
                ViewBag.fajr = fajr;
                ViewBag.dhuhr = dhuhr;
                ViewBag.asr = asr;
                ViewBag.maghrib = maghrib;
                ViewBag.sunrise = sunrise;
                ViewBag.isha = isha;
              

             
               
            }
            else
            {
                ViewBag.PrayerTimes = "Could not get data from the API";
            }


            string connection = "https://api.openweathermap.org/data/2.5/weather?q=rize&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document=XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value")?.Value;

            //Statistics
            Context c = new Context();
            ViewBag.v1 = c.WriterMessage.Where(x=> x.Receiver== values!.Email).Count();
            ViewBag.v2=c.Announcements.Count();
            ViewBag.v3 = c.Users.Count();
            ViewBag.v4 = c.Skills.Count();
            return View();
        }
    }
}
