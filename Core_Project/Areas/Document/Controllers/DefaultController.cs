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
            var values = DocumentManager.GetCourseNameDistinct();
            return View(values);
        }
        public IActionResult ViewDocumentsByName(string id)
        {
            var values = DocumentManager.GetDocumentsByCourseName(id);
            return View(values);
        }


        [HttpGet]
        public IActionResult AddDocument()
        {

            return View();  
        }
        [HttpPost]
        public IActionResult AddDocument(AddDocumentsViewModel p)
        {
            if (p.PdfFile != null && p.PdfFile.Length > 0)
            {
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Documents");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(p.PdfFile.FileName);
                var filePath = Path.Combine(folderPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    p.PdfFile.CopyTo(stream);
                }

              
                var document = new Documents
                {
                    CourseName = p.CourseName,
                    Title = p.Title,
                    PdfLink = "/Documents/" + uniqueFileName 
                };

                DocumentManager.TAdd(document); 

                return RedirectToAction("Index", "Default");
            }

            return View(p);
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
