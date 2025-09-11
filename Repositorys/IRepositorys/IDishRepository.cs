using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys
{
    public interface IDishRepository
    {
        Task<List<Dish>> GetAllDishesRepAsync();
        Task<Dish?> GetDishByIdRepoAsync(int id);
        Task<Dish?> GetDishByNameRepoAsync(string name);
        Task<int> AddDishRepoAsyn(Dish dish);
        Task<int> AddDishToMenuRepoAsync(int dishId, int menuId);
        Task<int> UpdateDishRepoAsync(Dish dish);
        Task<int> DeleteDishRepoAsync(int id);
        Task<Dish?> AddDishFromApiRepoAsync(Dish apiDish);

    }
}
