using Microsoft.AspNetCore.Mvc;
using System;
using WebDevGroupProject.Models;

namespace WebDevGroupProject.Controllers
{
    public class GuestBookingController : Controller
    {
        private readonly AppDbContext _db;

        public GuestBookingController(AppDbContext db)
        {
            _db = db;
        }

        public ActionResult BookService(string serviceType, int serviceId)
        {
            dynamic service = null;
            switch (serviceType.ToLower())
            {
                case "flight":
                    service = _db.Flights.Find(serviceId);
                    break;
                case "hotel":
                    service = _db.Hotels.Find(serviceId);
                    break;
                case "carrental":
                    service = _db.CarRentals.Find(serviceId);
                    break;
                default:
                    return NotFound();
            }

            if (service == null) return NotFound();

            ViewBag.ServiceType = serviceType;
            ViewBag.ServiceId = serviceId;
          
            return View("BookService"); 

        [HttpPost]
        public ActionResult ConfirmBooking(string serviceType, int serviceId, string passengerName)
        {
            DateTime bookingDateTime = DateTime.Now; 
            switch (serviceType.ToLower())
            {
                case "flight":
                    var flight = _db.Flights.Find(serviceId);
                    if (flight != null) bookingDateTime = flight.DepartureTime;
                    break;
                case "hotel":
               
                    break;
                case "carrental":
                    
                    break;
                default:
                    return NotFound();
            }

            var booking = new Booking
            {
                ServiceType = serviceType,
                ServiceId = serviceId,
                PassengerName = passengerName,
                BookingDateTime = bookingDateTime
            };

            _db.Bookings.Add(booking);
            _db.SaveChanges();

            TempData["BookingMessage"] = $"Awesome! Booking confirmed for {passengerName} on {serviceType} {serviceId}.";
            return RedirectToAction("Confirmation");
        }

       
        public ActionResult Confirmation()
        {
            return View();
        }
    }
}