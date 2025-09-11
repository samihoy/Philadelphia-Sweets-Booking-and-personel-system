

using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.BookingDTO_s;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services.IServices
{
    public interface IBookingService
    {
        Task<List<GetBookingDTO>> GetAllBookingsServicesAsync();
        Task<GetBookingDTO> GetBookingByIdServicesAsync(int id);
        Task<int> CreateBookingServicesAsync(CreateBookingDTO bookingDTO);
        Task<int> UpdateBookingServicesAsync(UpdateBookingDTO bookingDTO, int id);
        Task<int> DeleteBookingServicesAsyc(int bookingId);
    }
}
