using Core_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Core_Project.Areas.Writer.Models; // UserRegisterViewModel için
using EntityLayer.Concrete;            // WriterUser için


namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]

    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]

        public IActionResult Index()
        {

          
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                WriterUser w = new WriterUser(); 
                {
                  
                 
                   
                }


            }
            return View();
        }
    }
}
