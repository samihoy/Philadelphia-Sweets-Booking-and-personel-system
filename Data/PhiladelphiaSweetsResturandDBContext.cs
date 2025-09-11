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
        public DbSet<Menu> Menues { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var TableModel = modelBuilder.Entity<Table>();
            var BookingModel = modelBuilder.Entity<Booking>();
            var MenuModel = modelBuilder.Entity<Menu>();
            var DishModel = modelBuilder.Entity<Dish>();
            var EmployeeModel = modelBuilder.Entity<Employee>();

            EmployeeModel.HasData
                (
                    new Employee { Id=1, Fname="max", Lname="lundberg",Email="mail@role.com", Role="admin", PasswordHash= "$2a$11$IEs5ywZPW2iRRKW5/GV.we3k2PpmGXOVgbXcZOQ3ufUbk4ZmvJHTm" }
                );
            TableModel.HasData
                (
                    new Table { Id=1, TableNumber=1, Seats=6 },
                    new Table { Id = 2, TableNumber = 2, Seats = 10 }

                );
            // I seeded 2 bookings to test geting the bookings but only one has an actual time for testing
            // just in case somone rewivs this code and is confused
            BookingModel.HasData
                (
                    new Booking { Id = 1,StartTime=new DateTime(2025,09,05,18,0,0), DurationMinutes=120, NumberGuests = 10, BookedUnderName = "Max Lundberg", ContactInformationPhone = "0707254421" },
                    new Booking { Id=2,NumberGuests=4 ,BookedUnderName="Felix Lundberg", ContactInformationPhone="05627321"}
                );
            MenuModel.HasData
                (
                    new Menu { Id=1, Theme="vegetarian"},
                    new Menu { Id=2, Theme="meditteranian"}
                );
            DishModel.HasData
                (
                    new Dish { Id=1,Name="I made this....", Description="Generic dish 1", Ingredients = { "Your soul" }, Price=120},
                    new Dish { Id=2,Name="I made this.....", Description="Generic dish 2", Ingredients= {"the soul of your enemy?"}, Price=400}
                );

            // this seeding below was writen by AI for anyone looking at this code,
            // its seeding a join table to conect a table and booking with each other

            modelBuilder.Entity<Booking>()
                        .HasMany(b => b.Tables)
                        .WithMany(t => t.Bookings)
                        .UsingEntity<Dictionary<string, object>>("BookingTable",
                            b => b.HasOne<Table>()
                                .WithMany()
                                .HasForeignKey("TablesId"),
                            t => t.HasOne<Booking>()
                                .WithMany()
                                .HasForeignKey("BookingsId"),
                                    join =>
                                            {
                                                join.HasKey("BookingsId", "TablesId");
                                                join.HasData(
                                                    new { BookingsId = 1, TablesId = 1 }
                                                );
                                            }
                                                    );

        }
    }
}
