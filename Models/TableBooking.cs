using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class TableBooking
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Table")]
        public int TableId { get; set; }
        public Table Table { get; set; }

        [ForeignKey("Bokking")]
        public int BookingId { get; set; }
        public Booking Booking { get; set; }

        public DateTime BookedAt { get; set; } = DateTime.UtcNow;
        public Employee MadeBooking { get; set; }


    }
}
