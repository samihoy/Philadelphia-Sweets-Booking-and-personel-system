using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.BookingDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.DTO_s.TableDTO_s
{
    public class GetTableDTO
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public ICollection<GetBookingDTO> Bookings { get; set; }
    }
}
