namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();





    }
}
