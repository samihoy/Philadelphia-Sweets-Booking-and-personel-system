using System.ComponentModel.DataAnnotations;

namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Fname { get; set; }
        [Required]
        [MaxLength(100)]
        public string Lname { get; set; }
        public int? PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [MaxLength(80)]
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string? EmergencyContact { get; set; }
        public double? HourlySalery { get; set; }
        public ICollection<Shift> Shifts { get; set; }= new List<Shift>();














    }
}
