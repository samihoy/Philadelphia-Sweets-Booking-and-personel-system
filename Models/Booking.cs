namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class Booking
    {
        public int Id { get; set; }

        // --- Basic info ---
        public int NumberGuests { get; set; }
        public string BookedUnderName { get; set; }

        // ❌ Fix contact info: should be string, not int
        public string ContactInformationPhone { get; set; }
        public string ContactInformationMail { get; set; }

        // --- Time ---
        public DateTime StartTime { get; set; }
        public int DurationMinutes { get; set; } = 120;

        // --- Navigation ---
        public ICollection<TableBooking> TableBookings { get; set; } = new List<TableBooking>();


    }
}
