using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class DocumentController : Controller
    {
        DocumentManager DocumentManager = new DocumentManager(new EFDocumentDAL());

        public IActionResult Index()
        {
            var values = DocumentManager.TGetList();
            return View(values);
          
        }
        public IActionResult DocumentList(string id)
        {
            
          
            var values = DocumentManager.GetDocumentsByCourseName(id);
            return View(values);

        }
    }
}
