namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int Seats { get; set; }
        public ICollection<TableBooking> Booking { get; set; } = new List<TableBooking>();





    }
}
