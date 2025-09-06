using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys
{
    public interface ITableBookingRepository
    {
        Task<List<TableBooking>> RepoGetAllAsync();
        Task<TableBooking?> RepoGetByIdAsync(int Id);
        Task<int> RepoAddAsync(TableBooking tableBooking);
        Task<int> RepoUpdateAsync(TableBooking tableBooking);
        Task<int> RepoDeleteAsync(int Id);
    }
}
