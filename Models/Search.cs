using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebDevGroupProject.Migrations;

namespace WebDevGroupProject.Models
{
	public class Search
	{
		public List<Flight> Flights { get; set; }
		public List<Hotel> Hotels { get; set; }
		public List<Car_Rental> Car_Rentals { get; set; }

		public Search(List<Flight> flights, List<Hotel> hotels, List<Car_Rental> car_Rentals)
		{
			Flights = flights;
			Hotels = hotels;
			Car_Rentals = car_Rentals;
		}
	}
}
