using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]

    public class DocumentController : Controller
    {
        DocumentManager DocumentManager = new DocumentManager(new EFDocumentDAL());

        public IActionResult Index()
        {
            var courseNames = DocumentManager.GetCourseNameDistinct();
                          

            return View(courseNames);
          
        }
        public IActionResult DocumentList(string id)
        {
            
          
            var values = DocumentManager.GetDocumentsByCourseName(id);
            return View(values);

        }
    }
}
