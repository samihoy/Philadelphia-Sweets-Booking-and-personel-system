using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.ResturantBookingDTO_s;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services.IServices
{
    public interface IBookingService
    {
        Task<List<CreateBookingDTO>> GetAllBookingDTOs();
        Task<CreateBookingDTO> GetBookingDTO();
        Task<int> CreateBookingDTO(CreateBookingDTO bookingDTO);
        Task<int> UpdateBooking(CreateBookingDTO bookingDTO);
        Task<int> RemoverBookingAsyc(int bookingId);
    }
}
