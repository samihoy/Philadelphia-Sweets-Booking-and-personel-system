using System.ComponentModel.DataAnnotations;

namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        [Phone]
        public int Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }


    }
}
