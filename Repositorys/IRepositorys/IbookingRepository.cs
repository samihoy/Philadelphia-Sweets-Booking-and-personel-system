using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys
{
    public interface IbookingRepository
    {
        Task<List<Booking>> GetAllBookingAsync();
        Task<Booking?> GetBookingAsync(int bookingId);
        Task<int> AddBookingAsync(Booking booking);
        Task<int> EditBookingAsync(Booking booking);
        Task<int> DeleteBookingAsync(int bookingId);

    }
}
