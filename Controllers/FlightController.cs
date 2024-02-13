﻿using System;
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


		public IActionResult Index()
		{
			var flights = _db.Flights.ToList();
			return View(flights);
		}

		
		public IActionResult Details(int? id)
		{
			var flight = _db.Flights.FirstOrDefault(m => m.FlightId == id);
			if (flight == null) return NotFound();
			return View(flight);
		}


		public IActionResult Create()
		{
			return View();
		}


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FlightId,Airlines,Departure,Arrival,Prices")] Flights flight)
        {
            if (ModelState.IsValid)
            {
                _db.Add(flight);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }


        public IActionResult Edit(int? id)
		{
			var flight = _db.Flights.Find(id);
			if (flight == null) return NotFound();
			return View(flight);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("FlightId,Airlines,Departure,Arrival,Prices")] Flights flight)
		{
			if (id != flight.FlightId) return NotFound();

            if (ModelState.IsValid)
			{
				try
				{
					_db.Update(flight);
					_db.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!FlightExists(flight.FlightId))
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
			return View(flight);
		}
		private bool FlightExists(int id)
		{
			return _db.Flights.Any(e => e.FlightId == id);
		}


		public IActionResult Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var flight = _db.Flights.FirstOrDefault(m => m.FlightId == id);
			if (flight == null) return NotFound();

			return View(flight);
		}


		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var flight = _db.Flights.Find(id);
			_db.Flights.Remove(flight);
			_db.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		
	}
}
