using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.DTO_s.ResturantBookingDTO_s
{
    public class BookingDTO
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
        public int BookingCapacity { get; set; }
        //-------------------------------------------------------------


        public Customer Customer { get; set; }
        public int TableId { get; set; }
    }
}
