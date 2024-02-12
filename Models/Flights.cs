using System.ComponentModel.DataAnnotations;

namespace WebDevGroupProject.Models
{
    public class Flights
    {
        [Key]
        public int FlightId { get; set; }
        public string Airlines { get; set;}
        [DataType(DataType.Date)]
        public DateTime Departure { get; set; }
        [DataType(DataType.Date)]
        public DateTime Arrival { get; set; }
        public int Prices { get; set; }
    }
}
