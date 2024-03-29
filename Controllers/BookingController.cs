using Microsoft.AspNetCore.Mvc;
using WebDevGroupProject.Models;
using WebDevGroupProject.Data;

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
             Car_Rental car = _db.Car_Rentals.Find(id);
             if (car == null) return NotFound();
             ViewBag.ServiceType = "car";
             ViewBag.ServiceId = id;
             return View();
         }

         [HttpPost]
         public ActionResult BookCar(int id, string passengerName)
         {
            Car_Rental car = _db.Car_Rentals.Find(id);
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
        
         [HttpGet]
         public ActionResult BookHotels(int id)
         {
             Hotel Hotel = _db.Hotels.Find(id);
             if (Hotel == null) return NotFound();
             ViewBag.ServiceType = "Hotel";
             ViewBag.ServiceId = id;
             return View();
         }


         [HttpPost]
         public ActionResult BookHotels(int id, string passengerName)
         {
            Hotel Hotel = _db.Hotels.Find(id);
            Booking booking = new Booking
             {
                 ServiceType = "Hotels",
                 ServiceId = id,
                 PassengerName = passengerName,
                 BookingDateTime = DateTime.Now
             };
             _db.Bookings.Add(booking);
             _db.SaveChanges();
             TempData["BookingMessage"] = $"Booking confirmed for {passengerName} In Hotel: {Hotel.HotelName}.";
             return RedirectToAction("Confirmation");
         }
         

        [HttpGet]
        public ActionResult Confirmation()
        {
            return View();
        }
    }
}
