using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDevGroupProject.Models;

namespace WebDevGroupProject.Controllers
{
    public class FlightsController : Controller
    {
        private readonly AppDbContext _db;

        public FlightsController(AppDbContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Flight> flights = _db.Flights.ToList();
            return View(flights);
        }

        
        public ActionResult Details(int id)
        {
            Flight flight = _db.Flights.Find(id);
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

        
        [HttpPost]
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
