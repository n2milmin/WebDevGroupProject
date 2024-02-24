using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebDevGroupProject.Models
{
    public class Search
    {
        [Required]
        public string? searchType { get; set; }
        public string? searchValue { get; set; }
        public string? location { get; set; }
        [DataType(DataType.Date)]
        public DateTime? startDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? endDate { get; set; }
        public int? passengerAmount { get; set; }
        [DataType(DataType.Time)]
        public DateTime? flightTimes { get; set; }
        public double? hotelRating { get; set; }
        public string? carModel { get; set; }
        public int? maxPrice { get; set; }
        public int? minPrice { get; set; }
    }
}
