using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDAL());
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
           
            _userManager = userManager;
        }

        public async Task<IActionResult> ReceiverMessage(string p)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p = user.Email;
            var values = writerMessageManager.GetListReceiverList(p);
            return View(values);
        }
        public async Task<IActionResult> SenderMessage(string p)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p = user.Email;
            var values = writerMessageManager.GetListSenderList(p);
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {

         
         
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p.Sender = user.Email;
            p.Date =Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.SenderName=user.Name;
            Context c = new Context();
            var usernameSurname=c.Users.Where(x=> x.Email ==p.Receiver).Select(y=> y.Name+" "+y.Surname).FirstOrDefault();
            p.ReceiverName=usernameSurname;


            writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessage", "Message");
        }
        public IActionResult DeleteMessage(int id)
        {
            var values = writerMessageManager.TGetBYID(id);
            writerMessageManager.TDelete(values);
            return RedirectToAction("Index","Default");


           

        }
    }
}
