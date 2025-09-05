namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public ICollection<Shift> Shifts { get; set; } = new List<Shift>();
    }
}
