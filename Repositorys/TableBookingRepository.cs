using Microsoft.EntityFrameworkCore;
using Philadelphia_Sweets_booking_System__Resturant_.Data;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys
{
    public class TableBookingRepository : ITableBookingRepository
    {
        private readonly PhiladelphiaSweetsResturandDBContext _context;

        public TableBookingRepository(PhiladelphiaSweetsResturandDBContext context)
        {
            _context = context;
        }

        public async Task<int> RepoAddAsync(TableBooking tableBooking)
        {
            _context.TableBookings.Add(tableBooking);
            await _context.SaveChangesAsync();
            return tableBooking.Id;
        }

        public async Task<int> RepoDeleteAsync(int Id)
        {
            var results = await _context.TableBookings.Where(t => t.Id == Id).ExecuteDeleteAsync();

            return results;

        }

        public async Task<List<TableBooking>> RepoGetAllAsync()
        {
            var tableBooking = await _context.TableBookings.ToListAsync();
            
            return tableBooking;
        }

        public async Task<TableBooking?> RepoGetByIdAsync(int Id)
        {
            var tableBooking = await _context.TableBookings.FirstOrDefaultAsync(t => t.Id == Id);

            return tableBooking;
        }

        public async Task<int> RepoUpdateAsync(TableBooking tableBooking)
        {
            _context.TableBookings.Update(tableBooking);
            await _context.SaveChangesAsync();
            return tableBooking.Id;
        }
    }
}
