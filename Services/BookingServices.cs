
using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.BookingDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Models;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepository;
using Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys;
using Philadelphia_Sweets_booking_System__Resturant_.Services.IServices;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services
{
    public class BookingServices : IBookingService
    {
        private readonly IBookingRepository _bookingrepo;
        private readonly ITableRepository _tablerepo;

        public BookingServices(IBookingRepository bookingRepo, ITableRepository tableRepo)
        {
            _bookingrepo = bookingRepo;
            _tablerepo = tableRepo;
        }
        public async Task<int> CreateBookingServicesAsync(CreateBookingDTO DTO, List<int> tableIds)
        {
            try
            {
                var tables = await _tablerepo.RepoGetTablesByIdAsync(tableIds);

                var booking = new Booking
                {
                    StartTime = DTO.StartTime,
                    NumberGuests = DTO.NumberGuests,
                    BookedUnderName = DTO.BookedUnderName,
                    ContactInformationPhone = DTO.ContactInformationPhone,
                    DurationMinutes = DTO.DurationMinutes,
                    Tables=tables
                };

                var tableId = await _bookingrepo.RepoAddAsync(booking);

                return tableId;
               
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("Operation failed, booking could not be completed");
            }
        }

        public async Task<int> DeleteBookingServicesAsyc(int bookingId)
        {
            try
            {
                var rowsDeleted = await _bookingrepo.RepoDeleteAsync(bookingId);

                return rowsDeleted;
            }
            catch(Exception ex)
            {
                throw new InvalidCastException($"Failed to delete Booking with ID {bookingId},{ex}");
            }
        }

        public async Task<List<BookingsDTO>> GetAllBookingsServicesAsync()
        {
            try
            { 
                var allBookings = await _bookingrepo.RepoGetAllAsync();

                var allBookingsDTOs = allBookings.Select(b => new BookingsDTO
                {
                    StartTime = b.StartTime,
                    DurationMinutes = b.DurationMinutes,
                    TableIds = b.Tables.Select(t=>t.Id).ToList()

                }).ToList();

                return allBookingsDTOs;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Failed to fetch tables, {ex}");
            }
        }

        public async Task<GetBookingDTO> GetBookingByIdServicesAsync(int id)
        {
            try
            {
                var booking = await _bookingrepo.RepoGetByIdAsync(id);

                var BookingDTO = new GetBookingDTO
                {
                    Id = booking.Id,
                    NumberGuests = booking.NumberGuests,
                    BookedUnderName = booking.BookedUnderName,
                    ContactInformationPhone = booking.ContactInformationPhone,
                    DurationMinutes = booking.DurationMinutes,
                    StartTime = booking.StartTime,
                    TableIds = booking.Tables.Select(t => t.Id).ToList()

                };
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException($"Operation failed could not get booking with ID {id} {ex}");
            }
        }

        public async Task<int> UpdateBookingServicesAsync(UpdateBookingDTO bookingDTO, int id)
        {
            try
            {
                var booking = await _bookingrepo.RepoGetByIdAsync(id);

                booking.DurationMinutes = bookingDTO.DurationMinutes;
                booking.BookedUnderName = bookingDTO.BookedUnderName;
                booking.ContactInformationPhone = bookingDTO.ContactInformationPhone;
                booking.ContactInformationMail = bookingDTO.ContactInformationMail;
                booking.StartTime = bookingDTO.StartTime;
                booking.NumberGuests = bookingDTO.NumberGuests;
                //gör imorgon
                //booking.Tables = bookingDTO.TablesId.Select()





                var updatedBooking = await _bookingrepo.RepoUpdateAsync();
            }
            catch(Exception ex)
            {
                throw new = InvalidOperationException($"Error operation failed {ex}");
            }
        
        }   
    }
}
