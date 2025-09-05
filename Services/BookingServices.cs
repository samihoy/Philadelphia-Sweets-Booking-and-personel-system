using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.ResturantBookingDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys;
using Philadelphia_Sweets_booking_System__Resturant_.Services.IServices;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services
{
    public class BookingServices :IBookingService
    {
        private readonly IbookingRepository _bookingrepo;

        public BookingServices(IbookingRepository repo)
        {
            _bookingrepo = repo;
        }

        public Task<int> AddBookingDTO(BookingDTO booking)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookingDTO>> GetAllBookingDTOs()
        {
            throw new NotImplementedException();
        }

        public Task<BookingDTO> GetBookingDTO()
        {
            throw new NotImplementedException();
        }

        public Task<int> RemovrBookingAsyc(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateBooking(BookingDTO booking)
        {
            throw new NotImplementedException();
        }
    }
}
