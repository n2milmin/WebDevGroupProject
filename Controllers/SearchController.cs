using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using WebDevGroupProject.Data;
using WebDevGroupProject.Models;

namespace WebDevGroupProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _db;
        public SearchController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

		[HttpGet]
		public IActionResult GeneralSearch(string searchValue, string searchType)
		{
			if (searchValue == "Flights")
			{
				return RedirectToAction("FlightSearch", "Search", new { searchValue });
			}
			else if (searchValue == "Hotels")
			{
				return RedirectToAction("HotelSearch", "Search", new { searchValue });
			}
			else if (searchValue == "CarRentals")
			{
				return RedirectToAction("CarRentalSearch","Search", new { searchValue });
			}

			return View();
		}

		[HttpGet("Search/{searchValue?}")]
		public async Task<IActionResult> FlightSearch(string searchValue)
		{
			
			return View();
		}

		[HttpGet]
		public IActionResult HotelSearch(string searchValue)
		{

			return View();
		}
		[HttpGet("Search/{searchValue?}")]
		public async Task<IActionResult> CarRentalSearch(string searchValue)
		{
			var query = from x in _db.Car_Rentals select x;
			if(!String.IsNullOrEmpty(searchValue) )
			{
                query = query.Where(x => x.CompanyName.Contains(searchValue)
                        || x.Location.Contains(searchValue)
                        || x.Model.Contains(searchValue));
                var car = await query.ToListAsync();
                ViewData["SearchPerformed"] = true;
                ViewData["searchValue"] = searchValue;
                return View("Index", car);
            }
			return View();
		}
	}
}
