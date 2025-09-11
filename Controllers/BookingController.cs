using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.BookingDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Services.IServices;

namespace Philadelphia_Sweets_booking_System__Resturant_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingServices;
        public BookingController(IBookingService context)
        {
            _bookingServices = context;
        }

        [HttpGet("allbookings")]
        public async Task<ActionResult<List<GetBookingDTO>>> GetAllBookings()
        {
            var bookings = await _bookingServices.GetAllBookingsServicesAsync();

            if(!bookings.Any())
            {
                return NotFound("no bookings found in system");
            }

            return Ok(bookings);
        }
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<GetBookingDTO>> GetBookingById(int id)
        {
            var booking = await _bookingServices.GetBookingByIdServicesAsync(id);

            if(booking==null)
            {
                return NotFound($"No booking found");
            }

            return Ok(booking);

        }

        [HttpPost("Create")]
        public async Task<ActionResult<int>> CreateBooking(CreateBookingDTO booking)
        {
            var bookingId = await _bookingServices.CreateBookingServicesAsync(booking);

            if(bookingId==0)
            {
                return BadRequest("Operation failed, booking could not be created");
            }
            return Ok(bookingId);
        }
        [HttpPut("update")]
        public async Task<ActionResult<int>> UpdateBooking(UpdateBookingDTO bookingInfo, int id)
        {
            var rowsAffected = await _bookingServices.UpdateBookingServicesAsync(bookingInfo, id);

            if(rowsAffected<=0)
            {
                return BadRequest("Failed to update table, 0 rows  affected");
            }

            return Ok($"Update Sucessesful, {rowsAffected} tables were changed"); 
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<int>> DeleteBooking(int id)
        {
            var rowsAffected = await _bookingServices.DeleteBookingServicesAsyc(id);

            if(rowsAffected<=0)
            {
                return BadRequest($"Failed to delete {id} Affected");
            }
            return Ok($"Succses, Deleted {rowsAffected} booking from database");
        }
    }
}
