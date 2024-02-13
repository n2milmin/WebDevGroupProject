using System.ComponentModel.DataAnnotations;

namespace WebDevGroupProject.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime BookingStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime BookingEnd { get; set; }
    }
}
