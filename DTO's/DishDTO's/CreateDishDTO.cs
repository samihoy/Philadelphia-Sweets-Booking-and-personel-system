using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.DTO_s.DishDTO_s
{
    public class CreateDishDTO
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<string> Ingredients { get; set; } = new List<string>();

    }
}
