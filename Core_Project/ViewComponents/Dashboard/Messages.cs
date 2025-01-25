using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class Messages:ViewComponent
    {
        //UsersMessagesManager messageManager = new UsersMessagesManager(new EFUSersMessagesDAL()); 
        public IViewComponentResult Invoke()
        {
            //var values = messageManager.GetUsersMessagesWithUsersService();
            return View();
        }
    }
}
