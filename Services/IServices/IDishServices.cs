using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.DishDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services.IServices
{
    public interface IDishServices
    {
        Task<List<DishDTO>> GetAllDishesServicesAsync();
        Task<DishDTO> GetDishByIdServicesAsync(int id);
        Task<DishDTO> GetDishByNameServicesAsync(string name);
        Task<int> AddDishServicesAsync(CreateDishDTO dishDto);
        Task<int> AddDishToMenuServicesAsync(int dishId, int menuId);
        Task<int> UpdateDishServicesAsync(UpdateDIshDTO updatedDishdto);
        Task<int> DeleteDishServicesAsync(int id);
        Task<int> AddDishFromApiServices(string dishName);

    }
}
