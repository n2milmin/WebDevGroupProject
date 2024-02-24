using Microsoft.AspNetCore.Mvc;
using WebDevGroupProject.Data;
using WebDevGroupProject.Models;

namespace WebDevGroupProject.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _db;

        public BookingController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult BookFlight(int id)
        {
            Flight flight = _db.Flights.Find(id);
            if (flight == null) return NotFound();
            ViewBag.ServiceType = "Flight";
            ViewBag.ServiceId = id;
            return View();
        }

        [HttpPost]
        public ActionResult BookFlight(int id, string passengerName)
        {
            Flight flight = _db.Flights.Find(id);
            Booking booking = new Booking
            {
                ServiceType = "Flight",
                ServiceId = id,
                PassengerName = passengerName,
                BookingDateTime = flight.DepartureTime
            };
            _db.Bookings.Add(booking);
            _db.SaveChanges();
            TempData["BookingMessage"] = $"Booking confirmed for {passengerName} on flight {id}.";
            return RedirectToAction("Confirmation");
        }

        [HttpGet]
        public ActionResult Confirmation()
        {
            return View();
        }
    }
}