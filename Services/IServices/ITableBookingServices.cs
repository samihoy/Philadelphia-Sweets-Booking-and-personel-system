using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services.IServices
{
    public interface ITableBookingServices
    {
        Task<List<TableBooking>> RepoGetAllAsync();
        Task<TableBooking?> RepoGetByIdAsync(int Id);
        Task<int> RepoAddAsync(TableBooking tableBooking);
        Task<int> RepoUpdateAsync(TableBooking tableBooking);
        Task<int> RepoDeleteAsync(int Id);
    }
}
