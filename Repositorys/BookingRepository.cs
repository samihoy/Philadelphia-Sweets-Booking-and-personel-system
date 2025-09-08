using Microsoft.EntityFrameworkCore;
using Philadelphia_Sweets_booking_System__Resturant_.Data;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys
{
    public class BookingRepository : IBookingRepository
    {
        private readonly PhiladelphiaSweetsResturandDBContext _context;

        public BookingRepository(PhiladelphiaSweetsResturandDBContext context)
        {
            _context = context;
        }

        public async Task<int> RepoAddAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking.Id;

            //var results =await _context.SaveChangesAsync();
            //if(results>0)
            //{
            //    return booking.Id;
            //}
            //throw new Exception("operation failed, table not added to database");
        }

        public async Task<int> RepoDeleteAsync(int bookingId)
        {
            var results = await _context.Bookings.Where(b => b.Id == bookingId).ExecuteDeleteAsync();

            return results;
        }

        public async Task<int> RepoUpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            var results = await _context.SaveChangesAsync();

            return booking.Id;
        }

        public Task<List<Booking>> RepoGetAllAsync()
        {
            var bookings = _context.Bookings.Include(t=>t.Tables).ToListAsync();
            return bookings;
        }

        public Task<Booking?> RepoGetByIdAsync(int bookingId)
        {
            var table = _context.Bookings.Include(t=>t.Tables).FirstOrDefaultAsync(b => b.Id == bookingId);
            return table;
        }
    }
}
