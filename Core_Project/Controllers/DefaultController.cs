using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Project.Controllers
{
    [AllowAnonymous]

    public class DefaultController : Controller
    {
        private readonly IEmailSender _emailSender;
        MessageManager messageManager = new MessageManager(new EFMessageDAL());


        public DefaultController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptsPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<JsonResult> SendMessage(Message p)
        {
            p.Date = DateTime.Now;
            p.Status = true;

          
            string mailMessage = $"{p.Name} Adlı Kişi Bir Yeni Contact Mesajı Bıraktı. Mesaj: {p.Content}";
            messageManager.TAdd(p);
            await _emailSender.SendEmailAsync("mrlslymn02@gmail.com", "Yeni Bir Mesajınız Var", mailMessage);

            return Json(new { success = true, message = "Message sent successfully!" });
        }


    }
}
