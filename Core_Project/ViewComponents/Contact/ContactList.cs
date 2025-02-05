using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Contact
{
    public class ContactList:ViewComponent
    {
        ContactManager contactManager = new ContactManager(new EFContactDAL());

        public IViewComponentResult Invoke()
        {
            var values = contactManager.TGetList().Take(3).ToList();
            return View(values);
        }

    }
}
