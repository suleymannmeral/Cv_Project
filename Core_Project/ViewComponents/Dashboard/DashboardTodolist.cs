using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Dashboard
{
    public class DashboardTodolist:ViewComponent
    {
        TodolistManager todolistManager = new TodolistManager(new EFTodolistDAL());
        public IViewComponentResult Invoke()
        {
            var values = todolistManager.TGetList();
            return View(values);
        }
    }
}
