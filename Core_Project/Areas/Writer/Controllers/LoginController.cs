using Core_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Core_Project.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]


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

                            return RedirectToAction("Index", "WriterDashboard");
                            
                        }
                        else
                        {

                            TempData["ErrorMessage"] = "Wrong Password";
                            return RedirectToAction("Index", "Login");
                           

                           

                        }
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Account Was Locked";

                    await _emailSender.SendEmailAsync(user.Email!, "Account", "Account was locked");

                }

            }
            else
            {
                TempData["ErrorMessage"] = "Username Not Found";
            }
         
            return View();

        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(UserResetPasswordViewModel p)
        {
            var user = await _userManager.FindByNameAsync(p.Username!);
            if (user != null)
            {
                var email = user.Email;
                var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetLink = Url.Action(
                    "ResetPassword", 
                    "Login",       
                    new { token = resetToken, email = user.Email }, 
                    Request.Scheme  
                );


                await _emailSender.SendEmailAsync(email!, "Reset Password",
                    $"Please reset your password using this link: <a href='{resetLink}'>Reset Password</a>");
            }

            ViewBag.Message = "If the email exists, a password reset link has been sent.";
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordViewModel
            {
                Token = token,
                Email = email
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                foreach (var error in errors)
                {
                    Console.WriteLine(error); 
                }
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (result.Succeeded)
                {
                    await _emailSender.SendEmailAsync(user.Email!, "İnformation", "Your password changed succesfully");
                    return RedirectToAction("Index", "Login");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Default");
        }


    }
}
