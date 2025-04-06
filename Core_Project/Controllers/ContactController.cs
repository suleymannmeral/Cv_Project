using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]

    public class ContactController : Controller
    {
        //MessageManager messageManager = new MessageManager(new EFMessageDAL());
        //public IActionResult Index()
        //{
        //    var values = messageManager.TGetList().OrderByDescending(x=>x.MessageID).ToList();
        //    return View(values);
        //}

        //public IActionResult DeleteContactMessage(int id)
        //{
        //    var values = messageManager.TGetBYID(id);
        //    messageManager.TDelete(values);
        //    return RedirectToAction("Index");
        //}
    }
}
