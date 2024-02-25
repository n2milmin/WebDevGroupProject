using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDevGroupProject.Data;
using WebDevGroupProject.Models;

namespace WebDevGroupProject.Controllers
{
    public class FlightController : Controller
    {
        private readonly AppDbContext _db;

        public FlightController(AppDbContext context)
        {
            _db = context;
        }
        public async Task<IActionResult> Index(string searchString, string sortBy)
        {
            var flight = from x in _db.Flights select x;

            if (sortBy == "ArrivalTime")
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    flight = flight.Where(s => s.ArrivalTime!.ToString().Contains(searchString));
					ViewData["searchString"] = searchString;
				}
				var results = flight.OrderBy(x => x.ArrivalTime);
                flight = results;
                ViewData["Airline"] = false;
                ViewData["ArrivalTime"] = true;
                ViewData["DepartTime"] = false;
                ViewData["Price"] = false;
            }
            else if (sortBy == "DepartureTime")
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    flight = flight.Where(s => s.DepartureTime!.ToString().Contains(searchString));
					ViewData["searchString"] = searchString;
				}
				var results = flight.OrderBy(x => x.DepartureTime);
                flight = results;
                ViewData["Airline"] = false;
                ViewData["ArrivalTime"] = false;
                ViewData["DepartTime"] = true;
                ViewData["Price"] = false;
            }
            else if (sortBy == "Price")
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    flight = flight.Where(s => s.Price.ToString()!.Contains(searchString));
					ViewData["searchString"] = searchString;
				}
				var results = flight.OrderBy(x => x.Price);
                flight = results;
                ViewData["Airline"] = false;
                ViewData["ArrivalTime"] = false;
                ViewData["DepartTime"] = false;
                ViewData["Price"] = true;
            }
            else
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    flight = flight.Where(s => s.Airline!.Contains(searchString));
                    ViewData["searchString"] = searchString;
                } 
                var results = flight.OrderBy(x => x.Airline);
                flight = results;
                ViewData["Airline"] = true;
                ViewData["ArrivalTime"] = false;
                ViewData["DepartTime"] = false;
                ViewData["Price"] = false;
			}

			return View(await flight.ToListAsync());
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var flight = _db.Flights.Find(id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight)
        {
            if (ModelState.IsValid)
            {
                _db.Flights.Add(flight);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flight);
        }
    }
}
