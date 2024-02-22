using System.ComponentModel.DataAnnotations;

namespace WebDevGroupProject.Models
{
    public class Booking
    {
        [Required]
        public int BookingId { get; set; }
        public string ServiceType { get; set; } 
        public int ServiceId { get; set; }
        public string PassengerName { get; set; }
        public DateTime BookingDateTime { get; set; }

    }
}