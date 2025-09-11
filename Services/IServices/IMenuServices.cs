using Philadelphia_Sweets_booking_System__Resturant_.DTO_s.MenuDTO_s;
using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.Services.IServices
{
    public interface IMenuServices
    {
        Task<List<MenuWithDishesDTO>> GetAllMenusWithDishesServicesAsync();
        Task<MenuWithDishesDTO?> GetMenuByIdWithDishesServicesAsync(int id);
        Task<int> AddNewMenuServicesAsync(CreateMenuDTO Dto);
        Task<int> UpdateMenuServicesAsync(UpdateMenuThemeDTO menuDto, int id);
        Task<int> DeleteMenuServicesAsync(int id);
    }
}
