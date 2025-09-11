using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.DTO_s.MenuDTO_s
{
    public class MenuWithDishesDTO
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public List<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
