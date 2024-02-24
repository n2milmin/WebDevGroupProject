using System.ComponentModel.DataAnnotations;

namespace WebDevGroupProject.Models
{
    public class Flight
    {
        [Required]
        public int FlightId { get; set; }

        [Display(Name = "Airline")]
        public string Airline { get; set; }

        [Display(Name = "Departure Time")]
        [DataType(DataType.Time)]
        public DateTime DepartureTime { get; set; }

        [Display(Name = "Arrival Time")]
        [DataType(DataType.Time)]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }
    }
}