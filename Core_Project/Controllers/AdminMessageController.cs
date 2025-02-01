using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EFWriterMessageDAL());
        public IActionResult Index()
        {
            string p = "meralsuleyman53@gmail.com";
            var values = messageManager.GetListReceiverList(p);
            return View(values);
        }

    }
}
