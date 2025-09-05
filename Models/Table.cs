namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Seats { get; set; }
        public bool IsAvalible { get; set; }
        public List<TableBooking> Booking { get; set; } = new List<TableBooking>();





    }
}
