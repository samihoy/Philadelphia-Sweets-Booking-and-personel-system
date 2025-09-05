using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.ResturantBookingDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
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

        public Task<int> CreateBookingDTO(CreateBookingDTO DTO)
        {
            var booking = new Booking
            {
                StartTime = DTO.StartTime,
                NumberGuests = DTO.NumberGuests,
                BookedUnderName = DTO.BookedUnderName,
                ContactInformationPhone = DTO.ContactInformationPhone,
                DurationMinutes = DTO.DurationMinutes
            };

            var tableBooking = DTO.TableIds.Select(tb => new TableBooking
            {
                TableId = tb,
                Booking = booking,
            }).ToList();

            _bookingrepo.AddBookingAsync(booking);
            
        }

        public Task<List<CreateBookingDTO>> GetAllBookingDTOs()
        {
            throw new NotImplementedException();
        }

        public Task<CreateBookingDTO> GetBookingDTO()
        {
            throw new NotImplementedException();
        }

        public Task<int> RemovrBookingAsyc(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateBooking(CreateBookingDTO booking)
        {
            throw new NotImplementedException();
        }
    }
}
