using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.DTO_s.ResturantBookingDTO_s
{
    public class CreateBookingDTO
    {
        public DateTime StartTime { get; set; }
        public int NumberGuests { get; set; }
        public string BookedUnderName { get; set; }
        public string ContactInformationPhone { get; set; }
        public int DurationMinutes { get; set; }
        public List<int> TableIds { get; set; }

    }
}
