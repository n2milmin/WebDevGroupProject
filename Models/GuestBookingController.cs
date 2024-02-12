using Microsoft.AspNetCore.Mvc;

namespace WebDevGroupProject.Models
{
    public class GuestBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
