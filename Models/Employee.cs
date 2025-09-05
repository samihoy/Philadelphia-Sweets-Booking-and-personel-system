namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int PhoneNumber { get; set; }
        public int Email { get; set; }
        public string Role { get; set; }
        public string EmergencyContact { get; set; }
        public double HourlySalery { get; set; }
        public ICollection<Shift> Shifts { get; set; }= new List<Shift>();












    }
}
