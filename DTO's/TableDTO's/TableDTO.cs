using Philadelphia_Sweets_booking_System__Resturant_.Models;
using System.ComponentModel.DataAnnotations;

namespace Philadelphia_Sweets_booking_System__Resturant_.DTO_s.ResturantTableDTO_s
{
    public class TableDTO
    {
        [Required]
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int Seats { get; set; }
    }
}
