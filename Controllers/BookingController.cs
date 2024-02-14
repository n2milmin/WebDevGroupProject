using System;
using System.Linq;
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

        
        public IActionResult Index()
        {
            var bookings = _db.Bookings.ToList();
            return View(bookings);
        }

        
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var booking = _db.Bookings.FirstOrDefault(m => m.Id == id);
            if (booking == null) return NotFound();

            return View(booking);
        }


        public IActionResult Create(int flightId, DateTime Departure, DateTime Arrival)
        {
            ViewData["FlightId"] = flightId;
            ViewData["Departure"] = Departure;
            ViewData["Arrival"] = Arrival;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,Price,BookingStart,BookingEnd")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _db.Add(booking);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Description,Price,BookingStart,BookingEnd")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(booking);
                    _db.SaveChanges();
                }
                catch (Exception)
                {
                    if (!BookingExists(booking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(booking);
        }

        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = _db.Bookings.FirstOrDefault(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var booking = _db.Bookings.Find(id);
            _db.Bookings.Remove(booking);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _db.Bookings.Any(e => e.Id == id);
        }
    }
}
