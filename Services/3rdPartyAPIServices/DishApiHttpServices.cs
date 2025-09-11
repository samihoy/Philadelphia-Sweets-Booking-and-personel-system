using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.DishDTO_s;
using static System.Net.WebRequestMethods;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services
{
    public class DishApiHttpServices
    {
        private readonly HttpClient _Http;

        public DishApiHttpServices(HttpClient http)
        {
            _Http = http;
        }
        public async Task<DishApi> GetDishFromApiAsync (string searchName)
        {
            var response = await _Http.GetFromJsonAsync<DishApiResponseDTO>($"api/json/v1/1/search.php?s={searchName}");
            return response?.Meals?.FirstOrDefault();
        }
    }
}
