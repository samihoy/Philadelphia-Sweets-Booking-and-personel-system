using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.DTO_s.DishDTO_s
{
    public class AddDishToMenuDTO
    {
        public int Id { get; set; }
        public ICollection<int> Menus { get; set; } = new List<int>();

    }
}
