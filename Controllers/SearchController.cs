using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
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

		public async Task<IActionResult> Index(string searchString)
		{
			var flight = from x in _db.Flights select x;
			var hotel = from x in _db.Hotels select x;
			var car = from x in _db.Car_Rentals select x;

			flight = flight.Where(x => x.Airline!.Contains(searchString)
				|| x.ArrivalTime.ToString()!.Contains(searchString)
				|| x.DepartureTime.ToString()!.Contains(searchString)
				|| x.Price.ToString()!.Contains(searchString)
				);
			hotel = hotel.Where(x => x.HotelName!.Contains(searchString)
				|| x.Location!.Contains(searchString)
				|| x.Amenitites!.Contains(searchString)
				|| x.Price.ToString()!.Contains(searchString)
				);
			car = car.Where(x => x.CompanyName!.Contains(searchString)
				|| x.Location!.Contains(searchString)
				|| x.Model!.Contains(searchString)
				|| x.Pricing.ToString()!.Contains(searchString)
				);

			List<Flight> fly = new List<Flight>();
			fly = flight.ToList();
			List<Hotel> h = new List<Hotel>();
			h = hotel.ToList();
			List<Car_Rental> c = new List<Car_Rental>();
			c = car.ToList();
			var result = new Search(fly, h, c);

			return View(result);
		}

	}
}
