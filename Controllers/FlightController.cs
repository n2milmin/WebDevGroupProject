using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Syncfusion.EJ2.Buttons;
using WebDevGroupProject.Data;

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
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
    }
}
