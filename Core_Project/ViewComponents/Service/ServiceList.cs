﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.ViewComponents.Service
{
    public class ServiceList:ViewComponent
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceDAL());
        public IViewComponentResult Invoke()
        {
            var values = serviceManager.TGetList(); 
            return View(values);
        }
    }
}
