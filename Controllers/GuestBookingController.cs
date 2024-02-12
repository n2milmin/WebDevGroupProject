using Microsoft.AspNetCore.Mvc;

namespace WebDevGroupProject.Controllers
{
    public class GuestBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
