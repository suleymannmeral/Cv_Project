using BusinessLayer.Concrete;
using Core_Project.Areas.Document.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Document.Controllers
{
    [Area("Document")]

    public class DefaultController : Controller
    {
        DocumentManager DocumentManager = new DocumentManager(new EFDocumentDAL());

        public IActionResult Index()
        {
            var values = DocumentManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDocument()
        {

            return View();  
        }
        [HttpPost]
        public  IActionResult AddDocument(Documents document)
        {
            
        
             DocumentManager.TAdd(document);
           
            
                return RedirectToAction("Index", "Default");
           

        }
        [HttpGet]
        public IActionResult EditDocument(int id)
        {
            var values = DocumentManager.TGetBYID(id);

            return View(values);
        }
        [HttpPost]
        public IActionResult EditDocument(Documents document)
        {

            DocumentManager.TUpdate(document);


            return RedirectToAction("Index", "Default", new { area = "Document" });


        }

        public IActionResult DeleteDocument(int id)
        {
            var values = DocumentManager.TGetBYID(id);
            DocumentManager.TDelete(values);
            return RedirectToAction("Index", "Default", new { area = "Document" });
        }
    }
}
