using Microsoft.EntityFrameworkCore;
using WebDevGroupProject.Models;

namespace WebDevGroupProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Car_Rental> Car_Rentals { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<GuestBooking> GuestBookings { get; set; }
    }
}
