﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptsPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult SendMessage(Message p)
        {
            //MessageManager messageManager = new MessageManager(new EFMessageDAL());
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Status = true;
            //messageManager.TAdd(p);

            return PartialView();
        }

    }
}
