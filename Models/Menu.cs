namespace Philadelphia_Sweets_booking_System__Resturant_.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Theme { get; set; }
        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);











    }
}
