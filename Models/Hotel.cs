using System.ComponentModel.DataAnnotations;

namespace WebDevGroupProject.Models
{
	public class Hotel
	{
		[Key]
		public int HotelId { get; set; }
		[Required]
		public string HotelName { get; set; }
		public string Location { get; set; }
		public string Amenitites { get; set; }
		public float Price { get; set; }
	}
}
