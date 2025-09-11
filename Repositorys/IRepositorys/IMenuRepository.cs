using Philadelphia_Sweets_booking_System__Resturant_.Models;

namespace Philadelphia_Sweets_booking_System__Resturant_.Repositorys.IRepositorys
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllMenusWithDishesRepoAsync();
        Task<Menu?> GetMenuByIdWithDishesRepoAsync(int id);
        //Task<int> AddDishToMenuRepoAsync(int id,Dish dish);
        Task<int> AddNewMenuRepoAsync(Menu menu);
        Task<int> UpdateMenuRepoAsync(Menu menu);
        Task<int> DeleteMenuRepoAsync(int id);
        //egna
        //Task<Menu?> GetMenuByTheme(string theme);

    }
}
