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
		public IActionResult Index()
		{
			var ordered = _db.Car_Rentals.OrderBy(x => x.CompanyName).ToList();
			return View(ordered);
		}

		public PartialViewResult SearchCars(string searchText)
		{
			var result = _db.Car_Rentals.Where(x => x.CompanyName.Contains(searchText.ToLower())
				|| x.Location.Contains(searchText.ToLower())
				|| x.Model.Contains(searchText.ToLower())).ToList();
			return PartialView("GridView", result);
		}


		[HttpGet("Search/{searchString?}")]
		public async Task<IActionResult> Search(string searchString)
		{
			var query = from x in _db.Car_Rentals select x;
			bool searchPerformed = !String.IsNullOrEmpty(searchString);
			if (searchPerformed)
			{
				query = query.Where(x => x.CompanyName.Contains(searchString) 
						|| x.Location.Contains(searchString) 
						|| x.Model.Contains(searchString));
				var car = await query.ToListAsync();
				ViewData["SearchPerformed"] = searchPerformed;
				ViewData["SearchString"] = searchString;
				return View("Index",car);
			}
			return View();
		}

		public IActionResult CarSearch(string searchBy, string searchValue)
		{
			try
			{
				var cars = _db.Car_Rentals.ToList();
				if (string.IsNullOrEmpty(searchValue))
				{
					if(searchBy.ToLower() == "CompanyName")
					{
						var searchByCompany = cars.Where(x => x.CompanyName.ToLower()
							.Contains(searchValue.ToLower()));
						return View(searchByCompany);
					}
					else if(searchBy.ToLower() == "Location")
					{
						var searchByCompany = cars.Where(x => x.Location.ToLower()
							.Contains(searchValue.ToLower()));
						return View(searchByCompany);
					}
					else if (searchBy.ToLower() == "Model")
					{
						var searchByCompany = cars.Where(x => x.Model.ToLower()
							.Contains(searchValue.ToLower()));
						return View(searchByCompany);
					}
					else
					{
						TempData["InfoMessage"] = "No information found to match search.";
					}
				}
			}
			catch
			{
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
	}
}
