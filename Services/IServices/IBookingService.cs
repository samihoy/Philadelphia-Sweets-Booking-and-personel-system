using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.ResturantBookingDTO_s;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services.IServices
{
    public interface IBookingService
    {
        Task<List<BookingDTO>> GetAllBookingDTOs();
        Task<BookingDTO> GetBookingDTO();
        Task<int> AddBookingDTO(BookingDTO booking);
        Task<int> UpdateBooking(BookingDTO booking);
        Task<int> RemovrBookingAsyc(int bookingId);
    }
}
