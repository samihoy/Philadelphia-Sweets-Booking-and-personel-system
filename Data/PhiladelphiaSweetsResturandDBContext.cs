using Microsoft.EntityFrameworkCore;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using System.Reflection.Emit;

namespace Philadelphia_Sweets_booking_System__Resturant_.Data
{
    public class PhiladelphiaSweetsResturandDBContext : DbContext
    {
        public PhiladelphiaSweetsResturandDBContext(DbContextOptions<PhiladelphiaSweetsResturandDBContext> options) : base(options)
        {
            
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Menue> Menues { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TableBooking> TableBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var TableModel = modelBuilder.Entity<Table>();

            TableModel.HasData
                (
                    new Table { Id=1, Number=1, Seats=6, IsAvalible=true},
                    new Table { Id = 2, Number = 2, Seats = 10, IsAvalible = true }

                );

        }
    }
}
