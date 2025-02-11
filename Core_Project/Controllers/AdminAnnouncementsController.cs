using BusinessLayer.Concrete;
using Core_Project.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminAnnouncementsController : Controller
    {
        AnnouncementsManager announcementsMnager = new AnnouncementsManager(new EFAnnouncementsDAL());
        private readonly IEmailSender _emailSender;
        private readonly UserManager<WriterUser> _userManager;

        public AdminAnnouncementsController(IEmailSender emailSender, UserManager<WriterUser> userManager)
        {
            _emailSender = emailSender;
            _userManager = userManager;
        }

        public IActionResult AnnouncementsList()
        {
            var values = announcementsMnager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAnnouncement()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement(CreateAnnouncementsViewModel p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            else
            {

                var announcement = new Announcements()
                {
                    Date = DateTime.Now,
                    Title=p.Title,
                    Status=p.Status,
                    Content=p.Content
                };

                announcementsMnager.TAdd(announcement);
                
                List<string> emails = _userManager.Users.Select(x => x.Email).ToList();

                var emailTasks = emails.Select(email =>
                    _emailSender.SendEmailAsync(email, p.Title, p.Content)).ToList();

                await Task.WhenAll(emailTasks);





                return RedirectToAction("Index");


            }

        }



    }
}
