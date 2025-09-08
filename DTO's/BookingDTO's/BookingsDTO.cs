namespace Philadelphia_Sweets_booking_System__Resturant_.DTO_s.BookingDTO_s
{
    public class BookingsDTO
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationMinutes { get; set; }
        public List<int> TableIds { get; set; }
    }
}
