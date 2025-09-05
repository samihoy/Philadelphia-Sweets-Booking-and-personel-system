using Microsoft.EntityFrameworkCore;
using Philadelphia_Sweets_booking_System__Resturant_.Data;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys
{
    public class BookingRepository : IbookingRepository
    {
        private readonly PhiladelphiaSweetsResturandDBContext _context;

        public BookingRepository(PhiladelphiaSweetsResturandDBContext context)
        {
            _context = context;
        }

        public async Task<int> RepoAddAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            var results =await _context.SaveChangesAsync();
            if(results>0)
            {
                return booking.Id;
            }
            throw new Exception("operation failed, table not added to database");
        }

        public async Task<int> RepoDeleteAsync(int bookingId)
        {
            var results = await _context.Bookings.Where(b => b.Id == bookingId).ExecuteDeleteAsync();

            return results>0 ? bookingId : 0;

            if (results > 0)
            {
                return bookingId;
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> RepoUpdateAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            var results = await _context.SaveChangesAsync();

            return results > 0 ? booking.Id : 0;
        }

        public Task<List<Booking>> RepoGetAllAsync()
        {
            var bookings = _context.Bookings.ToListAsync();
            return bookings;
        }

        public Task<Booking?> RepoGetByIdAsync(int bookingId)
        {
            var table = _context.Bookings.FirstOrDefaultAsync(b => b.Id == bookingId);
            return table;
        }
    }
}
