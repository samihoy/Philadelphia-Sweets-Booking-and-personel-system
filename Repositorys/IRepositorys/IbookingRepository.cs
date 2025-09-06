using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys
{
    public interface IBookingRepository
    {
        Task<List<Booking>> RepoGetAllAsync();
        Task<Booking?> RepoGetByIdAsync(int Id);
        Task<int> RepoAddAsync(Booking booking);
        Task<int> RepoUpdateAsync(Booking booking);
        Task<int> RepoDeleteAsync(int Id);
    }
}
