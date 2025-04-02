using Core_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]

    public class ProfileController : Controller
    {

        private readonly UserManager<WriterUser> _userManager;
       public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult>Index()
        {
            if(User.Identity?.Name==null)
            {
                return RedirectToAction("Login", "Index");
            }
            var values = await _userManager.FindByNameAsync(User.Identity.Name); // oturum açmış kullanıcının bilgileri
            if (values == null)
            {
                return NotFound("Kullanıcı Bulunamadı");
            }
            UserUpdateViewModel viewModel = new UserUpdateViewModel();
            viewModel.Name = values.Name;
            viewModel.Surname = values.Surname;
            viewModel.PictureURL=values.ImageUrl;
            
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserUpdateViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return View();
            }

        
            if (p.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(resource, "wwwroot/userImages/", imageName);

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await p.Picture.CopyToAsync(stream);
                }

                user.ImageUrl = imageName;
            }

            user.Name = p.Name;
            user.Surname = p.Surname;

            if (!string.IsNullOrWhiteSpace(p.Password))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Default");
            }

            return View();
        }

    }
}
