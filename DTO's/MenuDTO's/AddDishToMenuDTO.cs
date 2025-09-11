using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.DTO_s.MenuDTO_s
{
    public class AddDishToMenuDTO
    {
        public int Id { get; set; }
        public List<int> Dishes { get; set; } = new List<int>();
    }
}
