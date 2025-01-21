using Core_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]

    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        private readonly IEmailSender _emailSender;

        public RegisterController(UserManager<WriterUser> userManager,IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [HttpGet]

        public IActionResult Index()
        {

          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {
                WriterUser newUser = new WriterUser()
                {
                    UserName = p.UserName,
                    Email = p.Mail,
                    Name = p.Name,
                    Surname = p.Surname,
                    ImageUrl = p.ImageURL,


                };

                if (p.ConfirmPassword == p.Password)
                {
                    var result = await _userManager.CreateAsync(newUser, p.Password);
                    if (result.Succeeded)
                    {
                       await _emailSender.SendEmailAsync(p.Mail, "Register Message", "Register Process Successfully"+ "Dear"+p.Name+" "+p.Surname);
                        return RedirectToAction("Index", "Login");

                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }

                }


               
                
            }
            return View();


        }

    }
}
