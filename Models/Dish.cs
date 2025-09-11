namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public int Price { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public ICollection<Menu> Menus { get; set; } = new List<Menu>();
        public ICollection<string> Ingredients { get; set; } = new List<string>();
        public bool IsPopular { get; set; }
        public string? pictureUrl { get; set; }
        public string? Video { get; set; }










    }
}
