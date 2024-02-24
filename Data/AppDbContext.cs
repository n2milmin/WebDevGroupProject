using Microsoft.EntityFrameworkCore;
using WebDevGroupProject.Models;

namespace WebDevGroupProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Car_Rentals> Car_Rentals { get; set; }
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Hotels> Hotels { get; set; }
    }
}
