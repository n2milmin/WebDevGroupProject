using Microsoft.AspNetCore.Mvc;

namespace WebDevGroupProject.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
