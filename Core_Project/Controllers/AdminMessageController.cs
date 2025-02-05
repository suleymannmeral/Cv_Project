using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminMessageController : Controller
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EFWriterMessageDAL());
        public IActionResult AdminReceiverMessage()
        {
            string p = "meralsuleyman53@gmail.com";
            var values = messageManager.GetListReceiverList(p);
            return View(values);
        }
        public IActionResult AdminSenderMessage()
        {
            string p = "meralsuleyman53@gmail.com";
            var values = messageManager.GetListSenderList(p);
            return View(values);
        }


    }
}
