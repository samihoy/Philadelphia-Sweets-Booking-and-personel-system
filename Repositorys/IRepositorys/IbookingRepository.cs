using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingsRepoAsync();
        Task<Booking?> GetBookingByIdRepoAsync(int Id);
        Task<int> AddBookingRepoAsync(Booking booking);
        Task<int> UpdatebookingRepoAsync(Booking booking);
        Task<int> DeleteBookingRepoAsync(int Id);
    }
}
