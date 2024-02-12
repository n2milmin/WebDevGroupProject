using Microsoft.AspNetCore.Mvc;

namespace WebDevGroupProject.Models
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
