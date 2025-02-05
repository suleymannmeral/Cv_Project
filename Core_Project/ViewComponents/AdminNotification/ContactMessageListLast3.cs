using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.AdminNotification
{
    public class ContactMessageListLast3:ViewComponent
    {
        MessageManager contactManager = new MessageManager(new EFMessageDAL());

        public IViewComponentResult Invoke()
        {
            var values = contactManager.TGetList()
                            .OrderByDescending(x => x.MessageID) 
                            .Take(3)
                            .ToList();
         
            return View(values);
        }

    }
}
