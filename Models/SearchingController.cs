using Microsoft.AspNetCore.Mvc;

namespace WebDevGroupProject.Models
{
    public class SearchingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
