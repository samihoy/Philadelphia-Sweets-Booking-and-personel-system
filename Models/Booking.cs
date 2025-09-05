namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class Booking
    {
        public int Id { get; set; }
        //-------------------------------------------------------------
        public int NumberGuests { get; set; }
        public string BookedUnderName { get; set; }
        public int ContactInformainPhone { get; set; }
        public int ContactInformationMail { get; set; }
        //-------------------------------------------------------------
        public DateOnly Date { get; set; }
        public TimeOnly BookedTime { get; set; }
        //-------------------------------------------------------------
        public List<TableBooking> Table { get; set; } = new List<TableBooking>();
        public int BookingCapacity { get; set; }
        //-------------------------------------------------------------


        public Customer Customer { get; set; }
        public int TableId { get; set; }













    }
}
