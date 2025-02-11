using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminUserController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        private readonly IEmailSender _emailSender;


        public AdminUserController(UserManager<WriterUser> userManager,IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var values =  _userManager.Users.ToList();
            return View(values);
        }
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id); 
            if (user != null) 
            {
                await _userManager.DeleteAsync(user); 
            }

            return RedirectToAction("Index"); 
        }
        public async Task<IActionResult> EditBan(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı!");
            }


            if (user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.UtcNow )
            {
              
                await _userManager.SetLockoutEndDateAsync(user, null);
                await _userManager.ResetAccessFailedCountAsync(user);
               await _emailSender.SendEmailAsync(user.Email, "Banınız Kaldırıldı", "Hesabınız Açılmıştır. Bir Sorun Yaşarsanız Anasayfa Üzerinden İletişime Geçebilirsiniz");

              
             
            }
            else
            {
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddDays(1));
                await _emailSender.SendEmailAsync(user.Email, "Ban", "Hesabınız bir gün süre ile kilitlenmiştir.");



            }

            return RedirectToAction("Index");
        }

    }
}
