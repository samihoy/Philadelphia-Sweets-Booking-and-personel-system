using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.DTO_s.BookingDTO_s
{
    public class UpdateBookingDTO
    {
        public int NumberGuests { get; set; }
        public string BookedUnderName { get; set; }
        public string ContactInformationPhone { get; set; }
        public string ContactInformationMail { get; set; }

        public DateTime StartTime { get; set; }
        public int DurationMinutes { get; set; } = 120;
        public List<int> TablesId { get; set; }
        public Employee Bookedby { get; set; }
    }
}
