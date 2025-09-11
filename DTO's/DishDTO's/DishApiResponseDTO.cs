using System.Text.Json.Serialization;

namespace Philadelphia_Sweets_booking_System__Resturant_.DTO_s.DishDTO_s
{
    public class DishApiResponseDTO
    {
        [JsonPropertyName("meals")]
        public List<DishApi> Meals { get; set; }
    }
    public class DishApi
    {
        public string strMeal { get; set; }
        public string strCategory { get; set; }
        public string strInstructions { get; set; }
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public string strIngredient5 { get; set; }
        public string strIngredient6 { get; set; }
        public string strIngredient7 { get; set; }
        public string strIngredient8 { get; set; }
        public  string strMealThumb { get; set; }
        public string strYoutube { get; set; }

    }
}
