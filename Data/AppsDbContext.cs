using WebDevGroupProject.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

    {

    }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Booking> Bookings { get; set; }
}