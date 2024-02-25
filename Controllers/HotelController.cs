using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDevGroupProject.Data;
using WebDevGroupProject.Migrations;
using WebDevGroupProject.Models;

namespace WebDevGroupProject.Controllers
{
	public class HotelController : Controller
	{
		private readonly AppDbContext _db;

		public HotelController(AppDbContext context)
		{
			_db = context;
		}
		public async Task<IActionResult> Index(string searchString, string sortBy)
		{
			var hotel = from x in _db.Hotels select x;


			if (sortBy == "Location")
			{
				if (!String.IsNullOrEmpty(searchString))
				{
					hotel = hotel.Where(s => s.Location!.Contains(searchString));
					ViewData["searchString"] = searchString;
				}
				var results = hotel.OrderBy(x => x.Location);
				hotel = results;
				ViewData["HotelName"] = false;
				ViewData["Location"] = true;
				ViewData["Amenitites"] = false;
				ViewData["Price"] = false;
			}
			else if (sortBy == "Amenitites")
			{
				if (!String.IsNullOrEmpty(searchString))
				{
					hotel = hotel.Where(s => s.Amenitites!.Contains(searchString));
					ViewData["searchString"] = searchString;
				}
				var results = hotel.OrderBy(x => x.Amenitites);
				hotel = results;
				ViewData["HotelName"] = false;
				ViewData["Location"] = false;
				ViewData["Amenitites"] = true;
				ViewData["Price"] = false;
			}
			else if (sortBy == "Price")
			{
				if (!String.IsNullOrEmpty(searchString))
				{
					hotel = hotel.Where(s => s.Price.ToString()!.Contains(searchString));
					ViewData["searchString"] = searchString;
				}
				var results = hotel.OrderBy(x => x.Price);
				hotel = results;
				ViewData["HotelName"] = false;
				ViewData["Location"] = false;
				ViewData["Amenitites"] = false;
				ViewData["Price"] = true;
			}
			else
			{
				if (!String.IsNullOrEmpty(searchString))
				{
					hotel = hotel.Where(s => s.HotelName!.Contains(searchString));
					ViewData["searchString"] = searchString;
				}
				var results = hotel.OrderBy(x => x.HotelName);
				hotel = results;
				ViewData["HotelName"] = true;
				ViewData["Location"] = false;
				ViewData["Amenitites"] = false;
				ViewData["Price"] = false;
			}

			return View(await hotel.ToListAsync());
		}
	}
}
