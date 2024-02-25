using System.ComponentModel.DataAnnotations;

namespace WebDevGroupProject.Models
{
    public class CarRentals
    {
        [Key]
        public int RentalsId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string Model { get; set; }
        [DataType(DataType.Date)]
        public DateTime Availability { get; set; }
        public double Pricing { get; set; }

    }
}