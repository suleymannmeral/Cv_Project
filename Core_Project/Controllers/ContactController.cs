using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageDAL());
        public IActionResult Index()
        {
            var values = messageManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteContactMessage(int id)
        {
            var values = messageManager.TGetBYID(id);
            messageManager.TDelete(values);
            return View();
        }
    }
}
