using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Lists;
using System.Diagnostics;
using WebDevGroupProject.Data;
using WebDevGroupProject.Models;

namespace WebDevGroupProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly AppDbContext _db;

		public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
			_db = context;
		}

		public IActionResult Index(string searchString, string sortBy)
		{
			if (!string.IsNullOrEmpty(searchString))
			{
				if (sortBy == "Flights")
				{
					return RedirectToAction("Index", "Flight", searchString);
				}
				else if (sortBy == "Hotels")
				{
					return RedirectToAction("Index", "Hotel", searchString);
				}
				else if (sortBy == "CarRentals")
				{
					return RedirectToAction("Index", "Car_Rentals_", searchString);
				}
				else
				{
					return RedirectToAction("Index", "Search", searchString);
				}
			}

			ViewData["All"] = true;
			ViewData["Flights"] = false;
			ViewData["Hotels"] = false;
			ViewData["CarRentals"] = false;
			return View();
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
