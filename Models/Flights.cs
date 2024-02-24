using System.ComponentModel.DataAnnotations;

namespace WebDevGroupProject.Models
{
	public class Flights
	{
		[Key]
		public int FlightId { get; set; }
		[Required]
		public string Airline { get; set; }
		[DataType(DataType.DateTime)]
		public DateTime ArrivalTime { get; set; }
		[DataType(DataType.Date)]
		public DateTime DepartureTime { get; set; }
		public double Price { get; set; }

	}
}
