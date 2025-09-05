namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan ScheduledHours => End - Start;
        public TimeSpan WorkedHours { get; set; }
        public Employee Employee { get; set; }
        



        public record WorkHours(TimeOnly start,TimeOnly end);





    }
}
