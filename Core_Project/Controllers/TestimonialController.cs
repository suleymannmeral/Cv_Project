using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]

    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager= new TestimonialManager(new EFTestimonialDAL());

     

        public IActionResult Index()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }
        public async Task<IActionResult> ShowTestimonialUser(string name)
        {
            Context c = new Context();
            var user = c.Testimonials.Where(x => x.ClientName == name).FirstOrDefault();

            if (user == null)
            {
                return Json(new { success = false, message = "Kullanıcı bulunamadı." });
            }




            return Json(new
            {
                success = true,
                clientname = user.ClientName ,
  
              
                imageUrl = "/UserImages/" + user.ImageUrl
            });
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var value= testimonialManager.TGetBYID(id);
            testimonialManager.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
