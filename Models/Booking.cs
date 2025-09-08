namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int NumberGuests { get; set; }
        public string BookedUnderName { get; set; }
        public string ContactInformationPhone { get; set; }
        public string ContactInformationMail { get; set; }

        public DateTime StartTime { get; set; }
        public int DurationMinutes { get; set; } = 120;
        public ICollection<Table> Tables { get; set; } = new List<Table>();
        public Employee Bookedby { get; set; }


    }
}
