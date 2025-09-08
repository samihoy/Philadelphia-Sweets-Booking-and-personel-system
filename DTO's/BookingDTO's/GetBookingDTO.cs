namespace Philadelphia_Sweets_booking_System__Resturant_.DTO_s.BookingDTO_s
{
    public class GetBookingDTO
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public int NumberGuests { get; set; }
        public string BookedUnderName { get; set; }
        public string ContactInformationPhone { get; set; }
        public int DurationMinutes { get; set; }
        public List<int> TableIds { get; set; }
    }
}
