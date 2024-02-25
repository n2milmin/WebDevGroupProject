using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

		public IActionResult Index()
		{
			ViewData["ErrMsg"] = "";
			ViewData["NoInput"] = "";
			return View();
		}

		[HttpGet("Search/{searchString?}")]
		public IActionResult Index(string searchString, string sortBy)
		{
			ViewData["ErrMsg"] = "";
			ViewData["NoInput"] = "";
			@ViewData["searchString"] = searchString;

			if (!string.IsNullOrEmpty(searchString))
			{
				if (sortBy == "Flights")
				{
					ViewData["Airline"] = true;
					return RedirectToAction("Index", "Flight", new { searchString });
				}
				else if (sortBy == "Hotels")
				{
					ViewData["HotelName"] = true;
					return RedirectToAction("Index", "Hotel", new { searchString });
				}
				else if (sortBy == "CarRentals")
				{
					ViewData["CompanyName"] = true;
					return RedirectToAction("Index", "Car_Rentals_", new { searchString });
				}
				else
				{
					ViewData["ErrMsg"] = "Please specify the search parameters";
				}
			}

			ViewData["NoInput"] = "Please enter something to search.";
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
