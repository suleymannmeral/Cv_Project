using Microsoft.AspNetCore.Mvc;

namespace Core_Project.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HandleErrorCode(int statusCode)
        {
            if (statusCode == 404)
            {
                return View("NotFound"); // "NotFound" adında bir görünüm döndür
            }

            return View("Error"); // Diğer hatalar için genel bir sayfa döndür
        }
    }
}
