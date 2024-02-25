using Microsoft.AspNetCore.Mvc;
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
            TempData["BookingMessage"] = $"Booking confirmed for {passengerName} on flight {flight.Airline}.";
            return RedirectToAction("Confirmation");
        }

        [HttpGet]
         public ActionResult BookCar(int id)
         {
             CarRental car = _db.CarRentals.Find(id);
             if (car == null) return NotFound();
             ViewBag.ServiceType = "car";
             ViewBag.ServiceId = id;
             return View();
         }

         [HttpPost]
         public ActionResult BookCar(int id, string passengerName)
         {
            CarRental car = _db.CarRentals.Find(id);
            Booking booking = new Booking
             {
                 ServiceType = "Car",
                 ServiceId = id,
                 PassengerName = passengerName,
                 BookingDateTime = car.Availability
             };
             _db.Bookings.Add(booking);
             _db.SaveChanges();
             TempData["BookingMessage"] = $"Booking confirmed for {car.CompanyName} by {passengerName}.";
             return RedirectToAction("Confirmation");
         }
        /*
         [HttpGet]
         public ActionResult BookHotels(int id)
         {
             Hotels Hotel = _db.Hotel.Find(id);
             if (Hotel == null) return NotFound();
             ViewBag.ServiceType = "Hotel";
             ViewBag.ServiceId = id;
             return View();
         }


         [HttpPost]
         public ActionResult BookHotels(int id, string HotelName)
         {
             Flight flight = _db.Flights.Find(id);
             Booking booking = new Booking
             {
                 ServiceType = "Flight",
                 ServiceId = id,
                 PassengerName = HotelName,
                 BookingDateTime = HotelName.Availability
             };
             _db.Bookings.Add(booking);
             _db.SaveChanges();
             TempData["BookingMessage"] = $"Booking confirmed for {HotelName} Date: {HotelName.Availability}.";
             return RedirectToAction("Confirmation");
         }
         */

        [HttpGet]
        public ActionResult Confirmation()
        {
            return View();
        }
    }
}
