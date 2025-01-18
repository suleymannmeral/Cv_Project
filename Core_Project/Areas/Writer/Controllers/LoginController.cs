using Core_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing.Text;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]

    public class LoginController : Controller
    {
        private readonly SignInManager<WriterUser> _signInManager;
        private readonly UserManager<WriterUser> _userManager;
        private readonly IEmailSender _emailSender;



        public LoginController(SignInManager<WriterUser> signInManager, UserManager<WriterUser> userManager,IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            var user = await _userManager.FindByNameAsync(p.Username!);
            if (user != null) {
                if(user.LockoutEnd==null)
                {
                    if (ModelState.IsValid)
                    {
                        
                        var result = await _signInManager.PasswordSignInAsync(p.Username!, p.Password!, true, true);
                        if (result.Succeeded)
                        {
                            TempData["n1"] = user.Name+" "+user.Surname;
                            TempData["n2"] = user.ImageUrl;

                            return RedirectToAction("Index", "Default");
                            
                        }
                        else
                        {
                            ModelState.AddModelError("", "Wrong Password Or Username");

                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Account Was Locked");
                    await _emailSender.SendEmailAsync(user.Email!, "Account", "Account was locked. Please retry after 10 min");

                }

            }
         
            return View();

        }
    }
}
