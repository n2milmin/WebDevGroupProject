using System;
using System.ComponentModel.DataAnnotations;

namespace WebDevGroupProject.Models
{
    public class GuestBooking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        [StringLength(50)]
        public string ServiceType { get; set; }
        public int ServiceId { get; set; }
        [Required]
        [StringLength(100)]
        public string PassengerName { get; set; }
        [StringLength(100)]
        public string ContactName { get; set; }
        [Required]
        [StringLength(100)]
        public string ContactPhone { get; set; }
        [Required]
        [StringLength(100)]
        public string ContactEmail { get; set; }
        [StringLength(100)]
        public string SpecialRequests { get; set; }
        [Required]
        public DateTime BookingDateTime { get; set; }


        public GuestBooking()
        {
            BookingDateTime = DateTime.Now;
        }
    }
}