using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDAL());
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
           
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            p = user.Email;
            var values = writerMessageManager.TGetListbyFilter(p);
            return View(values);
        }
    }
}
