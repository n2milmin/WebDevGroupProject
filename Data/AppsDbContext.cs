using WebDevGroupProject.Models;
using Microsoft.EntityFrameworkCore;
using WebDevGroupProject.Migrations;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

    {

    }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<CarRental> CarRentals { get; set; }

}