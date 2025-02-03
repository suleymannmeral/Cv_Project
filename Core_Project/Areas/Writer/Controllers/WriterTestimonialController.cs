using BusinessLayer.Concrete;
using Core_Project.Areas.Writer.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class WriterTestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDAL());
        private readonly UserManager<WriterUser> _userManager;
        private readonly IEmailSender _emailSender;

        public WriterTestimonialController(UserManager<WriterUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }


        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTestimonial(AddTestimonialViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (ModelState.IsValid)
            {
                Testimonial newTestimonial = new Testimonial()
                {
                    ClientName=p.ClientName,
                    Company=p.Company,
                    Comment=p.Comment,
                    ImageUrl=user.ImageUrl,
                    JobTitle=p.JobTitle,
                    

                };

                 testimonialManager.TAdd(newTestimonial);
              
                




            }
            await _emailSender.SendEmailAsync("mrlslymn02@gmail.com", "Testimonial", "You have a Testimonial Notification,Check your website");

            return RedirectToAction("Index", "Default");

        }
    }
}
