using WebDevGroupProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebDevGroupProject.Data;

namespace WebDevGroupProject.Controllers
{
	public class Car_Rentals_Controller : Controller
	{
		private readonly AppDbContext _db;

		public Car_Rentals_Controller(AppDbContext context)
		{
			_db = context;
		}
		public async Task<IActionResult> Index(string searchString, string sortBy)
		{
			var car = from x in _db.Car_Rentals select x;

			if (sortBy == "Location")
			{
				if (!String.IsNullOrEmpty(searchString))
				{
					car = car.Where(s => s.Location!.Contains(searchString));
				}
				var results = car.OrderBy(x => x.Location);
				car = results;
				ViewData["CompanyName"] = false;
				ViewData["Location"] = true;
				ViewData["Model"] = false;
				ViewData["Availability"] = false;
				ViewData["Pricing"] = false;
			}
			else if (sortBy == "Model")
			{
				if (!String.IsNullOrEmpty(searchString))
				{
					car = car.Where(s => s.Model!.Contains(searchString));
				}
				var results = car.OrderBy(x => x.Model);
				car = results;
				ViewData["CompanyName"] = false;
				ViewData["Location"] = false;
				ViewData["Model"] = true;
				ViewData["Availability"] = false;
				ViewData["Pricing"] = false;
			}
			else if (sortBy == "Pricing")
			{
				if (!String.IsNullOrEmpty(searchString))
				{
					car = car.Where(s => s.Pricing.ToString()!.Contains(searchString));
				}
				var results = car.OrderBy(x => x.Pricing);
				car = results;
				ViewData["CompanyName"] = false;
				ViewData["Location"] = false;
				ViewData["Model"] = false;
				ViewData["Availability"] = false;
				ViewData["Pricing"] = true;
			}
			else
			{
				if (!String.IsNullOrEmpty(searchString))
				{
					car = car.Where(s => s.CompanyName!.Contains(searchString));
				}
				var results = car.OrderBy(x => x.CompanyName);
				car = results;
				ViewData["CompanyName"] = true;
				ViewData["Location"] = false;
				ViewData["Model"] = false;
				ViewData["Availability"] = false;
				ViewData["Pricing"] = false;
			}

			return View(await car.ToListAsync());
		}
	}
}
