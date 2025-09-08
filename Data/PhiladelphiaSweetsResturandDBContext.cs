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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var TableModel = modelBuilder.Entity<Table>();
            var BookingModel = modelBuilder.Entity<Booking>();

            TableModel.HasData
                (
                    new Table { Id=1, TableNumber=1, Seats=6 },
                    new Table { Id = 2, TableNumber = 2, Seats = 10 }

                );
            BookingModel.HasData
                (
                    new Booking { Id=1, BookedUnderName="Max Lundberg", ContactInformationPhone="0707254421"},
                    new Booking { Id=1, BookedUnderName="Felix Lundberg", ContactInformationPhone="05627321"}
                );

        }
    }
}
